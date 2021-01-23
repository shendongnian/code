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
                List<List<double>> data = GenerateData(5, 5).ToList<List<double>>();
                OutputData(data,"Before");
                foreach (List<double> item in data)
                {
                    item.Sort();
                }
                data.Sort(CompareListOfDoubles);
                OutputData(data,"After");
            }
            private IEnumerable<List<double>> GenerateData(int index1, int index2)
            {
                Random rnd = new Random(DateTime.UtcNow.Millisecond);
                List<double> result;
                for (int i = 0; i < index1; i++)
                {
                    result = new List<double>(index2);
                    for (int j = 0; j < index2; j++)
                    {
                        result.Add(rnd.NextDouble() * 2 - 1);
                    }
                    yield return result;
                }
            }
            private void OutputData(List<List<double>> data, string message)
            {
                Console.WriteLine(message);
                foreach (List<double> list in data)
                {
                    foreach (double datum in list)
                    {
                        Console.Write(datum);
                        Console.Write("\t");
                    }
                    Console.WriteLine();
                }
            }
            static int CompareListOfDoubles(List<double> a, List<double> b)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (i > b.Count) return -1;
                    if (a[i] > b[i]) return -1;
                    if (a[i] < b[i]) return 1;
                }
                if (b.Count > a.Count) return 1;
                return 0;
            }
            double[,] ConvertListListDoubleTo2DArray(List<List<double>> data)
            {
                double[,] result = new double[data.Count, data[0].Count];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = data[i][j];
                    }
                }
                return result;
            }
        }
