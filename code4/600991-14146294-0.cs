                public static string RemoveBetween(string s, string begin, string end)
                {
                    Regex regex = new Regex(string.Format("{0}{1}", begin, end));
                    return regex.Replace(s, string.Empty);
                }
