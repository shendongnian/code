    using (var reader = new StreamReader(inputFile))
    {
        using (var writer = new StreamWriter(outputFile))
        {
            string textLine;
            while ((textline = reader.ReadLine()) != null)
            {
                // Check for your particular needs, and write
                // to the output file if applicable
            }
        }
    }
