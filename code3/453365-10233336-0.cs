    try
    {
        // Create an instance of StreamReader to read from a file.
        // The using statement also closes the StreamReader.
        using (StreamReader sr = new StreamReader(@"C:********\temperature.txt"))
        {
            String line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    Console.WriteLine(line.Split('=')[1]);
                } 
                catch
                {
                    Console.WriteLine("Contained No equals sign: " + line);
                }
            }
        }
    }
    catch (Exception e)
    {
        // Let the user know what went wrong.
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
    }
