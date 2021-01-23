    namespace MyAssembly
    {
        public class MyClass
        {
            public int X { get; set; }
            public int Y { get; set; }
    
            public MyClass(int initialX, int initialY)
            {
                X = initialX;
                Y = initialY;
            }
    
            public int MyMethod(int count, string text)
            {
                Console.WriteLine("This is a normal method.");
                Console.WriteLine("Count: {0}", count);
                Console.WriteLine("Text: {0}", text);
    
                return this.X + this.Y;
            }
    
            public static void StaticMethod(int count, float radius)
            {
                Console.WriteLine("This is a static method call.");
                Console.WriteLine("Count: {0}", count);
                Console.WriteLine("Radius: {0}", radius);
            }
        }
    }
