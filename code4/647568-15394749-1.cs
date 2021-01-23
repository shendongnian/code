    private void button1_Click(object sender, EventArgs e)
    {
        char[] array = { 'a', 'b', 'c' };
        string s = "abc";
        s.Compare(array);
    }
...
    public static class StringUtils
    {
        public static int Compare(this String str, char[] chars)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            if (chars == null)
                throw new ArgumentNullException("chars");
            int max = Math.Min(str.Length, chars.Length);
            for (int i = 0; i < max; i++)
                if (str[i] < chars[i])
                    return -1;
                else if (str[i] > chars[i])
                    return 1;
            return str.Length.CompareTo(chars.Length);
        }
    }
