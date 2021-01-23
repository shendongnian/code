    using System;
    using System.Collections;
    namespace SO16071463
    {
        class Program
        {
            static void Main()
            {
                Console.Write("Enter in a number of the size of the ArrayList that you want: ");
                int arraySize = int.Parse(Console.ReadLine());
                if (arraySize > 0)
                {
                    ArrayList newList = new ArrayList { arraySize };
                    Console.WriteLine("the size of the array is {0}", newList.Count);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You did not create an ArrayList");
                }
                Console.WriteLine("here you can't access the array");
                Console.ReadLine();
            }
        }
    }
