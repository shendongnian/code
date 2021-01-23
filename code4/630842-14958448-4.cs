    var list = new List<string> { "0", "1", "2" };
    int a = 0, b = 2;
    while (a++ < b)
    {
        // Some Codes
        bool skipToNext = false;
        foreach (string s in list)
        {
            Debug.WriteLine("{0} - {1}", a, s);
            switch (s)
            {
                case "1":
                    if (1 > 0)
                    {
                        Debug.WriteLine("Skipping switch...");
                        skipToNext = true;
                        break;
                    }
            }
            if (skipToNext)
            {
                Debug.WriteLine("Skipping foreach...");
                break;
            }
        }
        // in the case of there being more code, you can now use continue
        if (skipToNext)
        {
            Debug.WriteLine("Skipping to next while...");
            continue;
        }
        // more code
    }
