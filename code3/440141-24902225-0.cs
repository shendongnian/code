    string line = reader.ReadLine();                    
    line = ParseCommasInQuotes(line);
    private string ParseCommasInQuotes(string arg)
        {
            bool foundEndQuote = false;
            bool foundStartQuote = false;
            StringBuilder output = new StringBuilder();
            //44 = comma
            //34 = double quote
            foreach (char element in arg)
            {
                if (foundEndQuote)
                {
                    foundStartQuote = false;
                    foundEndQuote = false;
                }
                if (element.Equals((Char)34) & (!foundEndQuote) & foundStartQuote)
                {
                    foundEndQuote = true;
                    continue;
                }
                if (element.Equals((Char)34) & !foundStartQuote)
                {
                    foundStartQuote = true;
                    continue;
                }
                if ((element.Equals((Char)44) & foundStartQuote))
                {
                    //skip the comma...its between double quotes
                }
                else
                {
                    output.Append(element);
                }
            }
            return output.ToString();
        }
