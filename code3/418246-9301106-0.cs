    // Taking Reed Copsey's naming advice
    public enum Color
    {
        LightBlue,
        LightGreen,
        DarkGreen,
        Black,
        White,
        LightGray,
        Yellow
    }
    
    public static class Colors
    {
        public static bool IsLightColor(this Color color)
        {
            switch(color){
                case Color.LightBlue:
                case Color.LightGreen:
                case Color.DarkGreen:
                case Color.LightGray:
                return true;
                default: 
                return false;
            }
        }
    }
