     private static string GetEncodedQuotes(string target) {
            
            string result = string.Empty;
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == '"')
                {
                    if (target[i - 1] != '=')
                        if (!Regex.IsMatch(target.Substring(i), @"^""\s[a-zA-Z]+="""))
                        {
                            result += "&quot;";
                            continue;
                        }
                }
                result += target[i];
            }
            return result;
        }
