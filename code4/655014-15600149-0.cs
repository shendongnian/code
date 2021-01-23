    public static class Extensions
    {
        public static int CountOf(this string data, Char c)
        {
            int count = 0;
            foreach(Char chk in data)
            {
                if(chk == c)
                   ++count;
            }
            return count;
        }
    }
