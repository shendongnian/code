    public static class MyExtension
    {
        public static int CharCountWithoutSpaces(this string str)
        {
            string[] arr = str.Split(' ');
            string allChars = "";
            foreach (string s in arr)
            {
                allChars += s;
            }
            int length = allChars.Length;
            return length;
        }
    }
