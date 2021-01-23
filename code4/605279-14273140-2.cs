    public static class Extensions
    {
        public static string ReplaceExact(this string value, 
                                          Dictionary<string, string> substitutions)
        {
            foreach (var p in substitutions)
            {
                Regex r = new Regex(string.Format(@"\b{0}\b", p.Key));
                value = r.Replace(value, p.Value);
            }
            return value;
        }
    }
