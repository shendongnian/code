    public struct Size
    {
        public double Width { get; set; }
        public double Height { get; set; }
    
        public override string ToString()
        {
            return Width + "x" + Height;
        }
    
        public static Size ParseJson(string json)
        {
            var size = json.Split('x');
            return new Size { 
                Width = double.Parse(size[0]), 
                Height = double.Parse(size[1]) 
            };
        }
    }
