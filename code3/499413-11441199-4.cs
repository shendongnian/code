    public static class Utilities
    {
        public static void Increase(this Color color, int value)
        {
            if(color.R >= color.G && color.R >= color.B)
               color.R += value;
            else if(color.G >= color.R && color.G >= color.B)
               color.G += value;
            else
               color.B += value;
        }
        
        public static void Decrease(this Color color, int value)
        {
            if(color.R >= color.G && color.R >= color.B)
               color.R -= value;
            else if(color.G >= color.R && color.G >= color.B)
               color.G -= value;
            else
               color.B -= value;
        }
    }
