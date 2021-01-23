    namespace ConsoleApplication1
    {
        public class Circle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("Draw a Circle");
            }
        }
        
        public abstract class Shape
        {    
            public abstract void Draw();
        }
    }
