    public class Apple
    {
        private string size  = "big";
        private string color = "red";
        public string  Size  { get { return size; }  set { size  = value; } } 
        public string  Color { get { return color; } set { color = value; } }
        public Apple() 
        { } // for private as default 
        public Apple(string Size, string Color) 
        { size = Size; color = Color; }   // if you don't want the private defaults
    }
