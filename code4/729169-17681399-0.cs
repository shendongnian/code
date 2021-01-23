    private string[] truncateText(string iniText, int colNumber, int noAddRows)
    {
        string[] outStrings = new string[noAddRows + 3];
        if (noAddRows == 0)
        {
            outStrings = new string[22];
        }
        outStrings[1] = iniText;
        int addBit = 10;
        int maxLength = (int)GridView1.Columns[colNumber].ItemStyle.Width.Value + addBit;
        int linesCount = 1;
    
        if (iniText.Length > maxLength)
        {
            outStrings[1] = iniText.Substring(0, maxLength); //New truncated string
            outStrings[2] = iniText.Substring(maxLength, iniText.Length - maxLength); //Remaining bit
            linesCount = 2;
            if (noAddRows > -1 && outStrings[2].Length > maxLength)
            {
                //Further lines of the truncated bit
                string remBit = outStrings[2].Substring(maxLength, outStrings[2].Length - maxLength);
                outStrings[2] = outStrings[2].Substring(0, maxLength);
                while (remBit.Length > 0)
                {
                    linesCount = linesCount + 1;
                    if ((noAddRows > 0 && linesCount > noAddRows + 2) || linesCount > 20)
                    {
                        linesCount = linesCount - 1;
                        if (remBit.Length > 0)
                        {
                            outStrings[linesCount] = outStrings[linesCount] + remBit;
                        }
                        break;
                    }
    
                    if (remBit.Length <= maxLength)
                    {
                        outStrings[linesCount] = remBit;
                        break;
                    }
                    else
                    {
                        outStrings[linesCount] = remBit.Substring(0, maxLength);
                        remBit = remBit.Substring(maxLength, remBit.Length - maxLength);
                    }
                }
            }
        }
    
        outStrings[0] = Convert.ToString(linesCount); //Total number of lines
    
        return outStrings;
    }
