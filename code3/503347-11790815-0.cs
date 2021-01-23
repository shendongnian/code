    private void ReadFile()
        {
            var lines = File.ReadLines("Data.csv");
            var numbers = new List<List<double>>();
            var separators = new[] { ',', ' ' };
            /*System.Threading.Tasks.*/
            Parallel.ForEach(lines, line =>
            {
                var list = new List<double>();
                foreach (var s in line.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                {
                    double i;
                    if (double.TryParse(s, out i))
                    {
                        list.Add(i);
                    }
                }
                lock (numbers)
                {
                    numbers.Add(list);
                }
            });
            var rowTotal = new double[numbers.Count];
            var rowMean = new double[numbers.Count];
            var totalInRow = new int[numbers.Count()];
            for (var row = 0; row < numbers.Count; row++)
            {
                var values = numbers[row].ToArray();
                rowTotal[row] = values.Sum();
                rowMean[row] = rowTotal[row] / values.Length;
                totalInRow[row] += values.Length;
            }
