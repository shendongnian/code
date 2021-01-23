    public static class Extensions
    { 
        public static string D2<T>(this T key) where T : ID2Able
        { 
            return ((int) key).ToString("D2"); 
        } 
    }
