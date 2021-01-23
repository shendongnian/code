    // Note the more conventional variable names, too...
    string file = Path.Combine(Environment.CurrentDirectory, "Dummy.txt");
    using (var writer = File.CreateText(file))
    {
        for (int i = 0; i < 100; i++)
        {
            writer.WriteLine(...);
        }
    }
