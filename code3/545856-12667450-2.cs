        string RemoveDuplicateChars(string key)
        {
            string table = string.Empty;
            string result = string.Empty;
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
