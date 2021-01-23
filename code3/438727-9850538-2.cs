    public static class CharExtensions
    {
        public static string ToOffOn(this char ch)
        {
            switch (ch)
            {
                case '0' : return "Off";
                case '1': return "On";
                default:
                    return ch.ToString(); // Or rise exception
            }            
        }
    }
