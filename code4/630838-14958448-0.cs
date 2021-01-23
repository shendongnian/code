    bool continueWhile = true;
    while (!reader.EndOfStream && continueWhile)  //COMEÇO DO WHILE
    {
        // Some Codes
        foreach (string s in checkedlistbox1.items)
        {
            switch (s)
            {
                case "1":
                    if (1 > 0)
                    {
                        ///HERE I WANT TO LEAVE TO THE NEXT INTERACTION OF THE WHILE
                        continueWhile = false;
                        break;
                    }
            }
            if (!continueWhile) break;
        }
    }
