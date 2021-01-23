    try
    {
        using (var writer = new StreamWriter(masterlog, true)) // append
        {
            try
            {
                foreach (var line in File.ReadLines(individualLogFile))
                {
                    writer.WriteLine(line);
                }
            }
            catch (exceptions that occur while writing)
            {
            }
        }
    }
    catch (exceptions that occur when trying to open the file)
    {
    }
