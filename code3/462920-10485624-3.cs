    public static class SearchExt
    {
        public static bool SafeSearch(this string q, string param)
        {
            return param == null ? false : param.ToLower().Contains(q);
        }
    }
