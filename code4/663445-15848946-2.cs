    using System;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                Somefunction();
            }
            static void Somefunction()
            {
                int threadamount = 100;
                int[] indices = new int[threadamount];
                for (int i = 0; i < threadamount; ++i)
                {
                    indices[i] = i;
                }
                int[] Array1 = new int[1],
                      Array2 = new int[2],
                      Array3 = new int[3];
                Parallel.ForEach<int>(indices, index =>
                {
                    if (index == 2)
                        Array1 = Array2;
                    else if (index == 3)
                        Array1 = Array3;
                    int[] test = Array1;
                    Console.WriteLine(Array1.Length);
                    if (!ReferenceEquals(test, Array1))
                    {
                        Console.WriteLine("Error!");
                    }
                 });
             }
        }
    }
