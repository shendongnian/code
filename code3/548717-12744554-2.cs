    public static partial class GlobalConstants
    {
        public static List<string> Lst; 
        static void AddVersionInfo(string mod)
        {
            if (Lst == null) Lst = new List<string>();
            Lst.Add(mod);
        }
    }
