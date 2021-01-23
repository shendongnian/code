    public static class TrimHelper
    {
        public static string[] SplitAndTrim(this string str, char splitChar, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            List<string> result = new List<string>();
    
            if (str != null)
            {
                foreach (var item in str.Split(splitChar, options))
                {
                    string val = item.Trim();
    
                    if (options == StringSplitOptions.RemoveEmptyEntries && val == string.Empty)
                        continue;
    
                    result.Add(val);
                }
            }
    
            return result.ToArray();
        }
    }
