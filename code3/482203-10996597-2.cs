    class Program
    {        
        public delegate void GetColorDel(out float r, out float g, out float b);
        static void Main(string[] args)
        {
            UpdateColourPicker(null, GetColorSky);
            UpdateColourPicker(null, GetColorGround);
            Console.Read();
        }
        static void GetColorSky(out float r, out float g, out float b) 
        {
            r = g = b = 0f;
            Console.WriteLine("sky"); 
        }
        static void GetColorGround(out float r, out float g, out float b) 
        {
            r = g = b = 0f;
            Console.WriteLine("ground"); 
        }
        static void UpdateColourPicker(object cp, GetColorDel cMethod) 
        {
            float r, g, b;
            cMethod(out r, out g, out b);
        }
    }
