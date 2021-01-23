    try
    {
        using (var stream = new FileStream("C:\\Test.txt", FileMode.CreateNew))
        using (var writer = new StreamWriter(stream))
        {
            //write file
        }
    }
    catch (IOException e)
    {
        if (e.HResult == -2147024816)
        {
            // File already exists.
        }
    }
