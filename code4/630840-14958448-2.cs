    while (!reader.EndOfStream)
    {
        // Some Codes
        bool skipToNext = false;
        foreach (string s in checkedlistbox1.items)
        {
            switch (s)
            {
                case "1":
                    if (1 > 0)
                    {
                        skipToNext = true;
                        break;
                    }
            }
            if (skipToNext) break;
        }
        // in the case of there being more code, you can now use continue
        if (skipToNext) continue;
        // more code
    }
