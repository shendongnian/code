    private bool processNextItem(StreamReader reader)
    {
        bool continueOuterLoop = true;
        foreach (string s in checkedlistbox1.items)
        {
            switch (s)
            {
                case "1":
                    if (1 > 0)
                    {
                        continueOuterLoop = false;
                        break;
                    }
            }
        }
        return continueOuterLoop;
    }
