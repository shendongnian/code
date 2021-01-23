        string RemoveDuplicateChars(string key)
        {
            string table = strimg.Empty;
            string result = strimg.Empty;
            foreach (char value in key)
            {
                if (table.IndexOf(value) == -1)
                {
                    table += value;
                    result += value;
                }
            }
            return result;
        }
