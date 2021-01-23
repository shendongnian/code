    public static class LocaleFactory
    {
        private static Dictionary<string, Locale> cache = new Dictionary<string, Locale>();
    
        public static Locale GetLocal(string localeString)
        {
            Locale output;
            if (cache.TryGetValue(localeString, out output))
            {
                return output;
            }
            else
            {
                output = new Locale(localeString);
                //do other creation stuff for the Locale
                cache.Add(localeString, output);
                return output;
            }
        }
    }
