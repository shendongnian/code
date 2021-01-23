        public static void ReadFile()
        {
            List<List<double>> numbers = new List<List<double>>();
            foreach (string line in File.ReadAllLines(@"c:\temp\test.csv"))
            {
                var list = new List<double>();
                foreach (string s in line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    double i;
                    if (Double.TryParse(s, out i))
                    {
                        list.Add(i);
                    }
                }
                numbers.Add(list);
            }
            double[] rowTotal = new double[numbers.Count];
            double[] squareRowTotal = new double[numbers.Count];
            double[] rowMean = new double[numbers.Count];
            for(int row = 0; row < numbers.Count; row++)
            {
                var values = numbers[row].ToArray();
                rowTotal[row] = values.Sum();
                squareRowTotal[row] = values.Select(v => v * v).Sum();
                rowMean[row] = rowTotal[row] / rowTotal.Count();
            }
        }
