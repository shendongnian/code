    StreamReader sr = new StreamReader("TestFile.txt");
    try
    {
        String line = sr.ReadToEnd();
        Console.WriteLine(line);
    }
    finally
    {
        // this block will be called even if exception occurs
        if (sr != null)
            sr.Dispose(); // same as sr.Close();
    }
