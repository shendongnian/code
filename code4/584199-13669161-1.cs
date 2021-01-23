    namespace StackOverflow.Demos
    {
        
        class Program
        {
            public static void Main(string[] args) 
            {
                new Program();
                Console.WriteLine("Done");
                Console.ReadKey();
            }
            Program()
            {
                double[,] data = GenerateData();
                OutputData(data, "Before");
                SortData(ref data);
                OutputData(data, "After");
            }
            double[,] GenerateData()
            {
                Random randomGenerator = new Random(DateTime.UtcNow.Millisecond);
                double[,] data = new double[5, 5];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        data[i, j] = (randomGenerator.NextDouble() * 2) - 1;
                    }
                }
                return data;
            }
            void OutputData(double[,] data, string message)
            {
                Console.WriteLine("=====================");
                Console.WriteLine(message);
                Console.WriteLine("=====================");
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        Console.Write(data[i, j]);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
            void SortData(ref double[,] data)
            {
                //sort sub arrays
                SortDataRows(ref data);
                //sort this array
                for (int i = 0; i < data.GetLength(0)-1; i++)
                {
                    for (int j = i; j < data.GetLength(0); j++)
                    {
                        for (int k = 0; k < data.GetLength(1); k++)
                        {
                            if (data[i, k].CompareTo(data[j, k]) < 0) //if already in order exit loop
                            {
                                break;
                            } else if (data[i, k].CompareTo(data[j, k]) > 0) //if out of order switch and loop
                            {
                                SwapRows(ref data, i, j);
                                break;
                            }//else orders are equal so far; continue to loop
                        }
                    }
                }
            }
            void SortDataRows(ref double[,] data)
            {
                for (int row = 0; row < data.GetLength(0); row++)
                {
                    for (int i = 0; i < data.GetLength(1) - 1; i++)
                    {
                        for (int j = i; j < data.GetLength(1); j++)
                        {
                            if (data[row, i].CompareTo(data[row, j]) > 0)
                            {
                                Swap<double>(ref data[row, i], ref data[row, j]);
                            }
                        }
                    }
                }
            }
            void Swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
            void SwapRows(ref double[,]data, int i, int j)
            {
                for (int k = 0; k < data.GetLength(1); k++)
                {
                    Swap<double>(ref data[i, k], ref data[j, k]);
                }
            }
        }
    }
