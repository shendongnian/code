    public static class Extension
    {
        private static Dictionary<Control, string> _controlStrings;
        public static void GetString(this Control ctrl)
        {
            return _controlStrings[ctrl];
        }
     }
