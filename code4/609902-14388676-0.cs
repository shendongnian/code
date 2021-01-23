    x.Split(new String[] { "|||" }, StringSplitOptions.None);
    Regex.Split(x, @"([a-zA-Z]+)\|\|\|([a-zA-Z]+)");
    public static class StringExtensions()
    {
        public static String Split(this String s, String delimiter)
        {        
            s.Split(new String[] { delimiter }, StringSplitOptions.None);
        {
    }
