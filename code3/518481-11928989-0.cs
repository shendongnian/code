    using (TextReader reader = File.OpenText(fullPath))
    {
        using (TextWriter writer = File.AppendText(outputFile))
        {
             while ((line = reader.ReadLine()) != null)
             {
                 // Logic to clean data
                writer.WriteLine(outputString);
             }
        }
    }
