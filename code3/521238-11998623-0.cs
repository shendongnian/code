    public static class Extensions
    {
        public static void AddPageTab(this Dictionary<string, PageTab> mydict, PageTab pt)
        {
            mydict.Add(pt.ID, pt);
        }
    }
