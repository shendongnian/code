    klubbar[antal] = GetKlubbFromString(line); 
    ^ this line is to replace the line in your stream reader section
    private static klubb GetKlubbFromString(string line)
        {
            string[] lineItems = line.Split('\t');
            //1       Harrys  True    6   100 blackjack   klubbfan
            return new klubb
                       {
                           id = Convert.ToInt32(lineItems[0]),
                           klubbnamn = lineItems[1],
                           vip = Convert.ToBoolean(lineItems[2]),
                           dansgolv = Convert.ToInt32(lineItems[3]),
                           intrade = Convert.ToInt32(lineItems[4]),
                           casino = lineItems[5],
                           genre = lineItems[6]
                       };
        }
