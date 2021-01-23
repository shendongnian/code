        using (var writer = new StreamWriter(@"C:\path\test.csv"))
        {
            foreach (var pair in data)
            {
                writer.WriteLine("{0},{1};", pair.Key, String.Join(",", pair.Value.Select(x => x.ToString()).ToArray()));
            }
        }
