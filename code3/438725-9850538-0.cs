    public static class CharExtensions
    {
        public static string ToOnOff(this char ch)
        {
            return (ch == '1') ? "On" : "Off";
        }
    }
