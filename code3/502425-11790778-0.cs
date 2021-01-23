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
