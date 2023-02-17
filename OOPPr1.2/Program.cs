using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPr1._2
{
    internal class Program
    {
        delegate int Delegat();
        delegate double DDelegat(Delegat[] a);

        static int Random()
        {
            Random random = new Random();
            int RandomNumber = random.Next(1, 20);
            Console.WriteLine(RandomNumber);
            return RandomNumber;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount of elements in array");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Elements in array: ");
            var array = new Delegat[k];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = () => new Delegat(Random)();
            }

            DDelegat d = delegate (Delegat[] a)
            {
                double av = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    av += a[i]();
                }
                return av / array.Length;
            };

            Console.WriteLine("Avarage = {0}", d(array));
            Console.WriteLine(new string('-', 50));

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]());
            }
        }
    }
}
