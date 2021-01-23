    public static class Extensions
    {
        public static string AsWord(this int num)
        {
            switch (num) 
            {
                case 1: return "ONE";  
                case 2: return "TWO";
                // ...
                default: throw new ArgumentException("num");
            }
        }
    }
