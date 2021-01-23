    public void ReadFile()
    {
        int lineNo = 0;
        List<List<double>> numbers = new List<List<double>>();
        foreach (string line in File.ReadAllLines("Data.txt"))
        {
            var list = new List<double>();
            foreach (string s in line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                double i;
                if (double.TryParse(s, out i))
                {
                    list.Add(i);
                    lineNo++;
                }
            }
            numbers.Add(list);
        }
        var rowsTotal = new List<double>(numbers.Count);
        var squareRowTotal = new List<double>(numbers.Count);
        var rowMean = new List<double>(numbers.Count);
        rowsTotal.AddRange(numbers.Select(row => row.Sum()));
        squareRowTotal.AddRange(numbers.Select(row => row.Sum(d => d*d)));
        for (int k = 0; k < lineNo; k++)
        {
            rowMean[k] = rowsTotal[k] / numbers[k].Count;
        }
    }
