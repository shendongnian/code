    public static IEnumerable<Customer> LoadCustomers(string filename)
    {
        if (File.Exists(filename))
        {
            foreach (var line in File.ReadAllLines(filename).Where(l => l.Contains(',')))
            {
                var splitLine = line.Split(',');
                if (splitLine.Count() >= 3)
                {
                    yield return new Customer
                    {
                        customerName = splitLine[0].Trim(),
                        customerAddress = splitLine[1].Trim(),
                        customerZip = Convert.ToInt32(splitLine[2].Trim())
                    };
                }
            }
        }
    }
