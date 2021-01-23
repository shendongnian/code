    public static class intExtensions
    {
        public static string NumberToString(this int number, bool flag = false)
        {
            return flag ? number.ToString("00") : number.ToString("0000");
        }
    }
