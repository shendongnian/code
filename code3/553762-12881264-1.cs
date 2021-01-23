    while (true)
    {
        try
        {
            using (FileStream stream = new FileStream("test_file.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    // bla bla bla does not matter
                }
            }
        }
        catch(Exception e)
        {
            // bla bla bla does not matter again
        }
        Thread.Sleep(500);
    }
