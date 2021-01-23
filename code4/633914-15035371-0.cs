    public static class MyExtensionMethods
    {
        public static void Show(this Control subject)
        {
            subject.Visible = true;
        }
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
