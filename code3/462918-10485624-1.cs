    private static Func<Country, bool> Predicate(string q)
    {
        return x => (
            q.SafeSearch(x.Name) ||
            q.SafeSearch(x.Description)
            );
    }
    public static class SearchExt
    {
        public static bool SafeSearch(this string q, string param)
        {
            return param == null ? false : param.ToLower().Contains(q);
        }
    }
