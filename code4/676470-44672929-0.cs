    public static class Extensions
    {
            static private List<string> trueSet = new List<string> { "true","1","yes","y" };
    
            public static Boolean ToBoolean(this string str)
            {
                try
                { return trueSet.Contains(str.ToLower()); }
                catch { return false; }
            }
    }
