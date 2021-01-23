     char[] check = test.SplitMeUp();
            
            if(check[0] == '1')
     static class Extensions
    {
        public static char[] SplitMeUp(this string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0; i < chars.Length; i++)
                chars[i] = str[i];
            return chars;
        }
    }
