    using (var input = File.OpenText("input.log"))
    using (var output = File.CreateText("output.log"))
    {
        string line;
        while ((line = input.ReadLine()) != null)
        {
            if (SomeConditionOnLine(line))
            {
                output.WriteLine(line);
            }
        }
    }
