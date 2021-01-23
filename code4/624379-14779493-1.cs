        static public string CsvQuote(this string text)
        {
            if (text == null)
            {
                return string.Empty;
            }
            bool containsQuote = false;
            bool containsComma = false;
            int len = text.Length;
            for (int i = 0; i < len && (containsComma == false || containsQuote == false); i++)
            {
                char ch = text[i];
                if (ch == '"')
                {
                    containsQuote = true;
                }
                else if (ch == ',' || char.IsControl(ch))
                {
                    containsComma = true;
                }
            }
            bool mustQuote = containsComma || containsQuote;
            if (containsQuote)
            {
                text = text.Replace("\"", "\"\"");
            }
            if (mustQuote)
            {
                return "\"" + text + "\"";  // Quote the cell and replace embedded quotes with double-quote
            }
            else
            {
                return text;
            }
        }
    }
