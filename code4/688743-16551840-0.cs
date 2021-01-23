    using (var writer = new StreamWriter(outputPath))
    {
        foreach (var line in File.ReadLines(filename)
        {
            foreach (var num in line.Split(','))
            {
                writer.Write(num + " ");
                writer.WriteLine(IsNumberValid(num));
            }
        }
    }
