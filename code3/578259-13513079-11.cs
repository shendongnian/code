    public class Program
    {
        public static void Main()
        {
            // Add the calculation algorithm defined below.
            OverlapCalculator.AddCalculation<Rectangle, Triangle>(IsOverlapping);
            var rect = new Rectangle();
            var triangle = new Triangle();
            var circle = new Circle();
            // These will work since we have a two way calculation for Rectangle and Triangle
            rect.IsOverlapping(triangle);
            triangle.IsOverlapping(rect);
            // This will throw since we have no calculation between Circle and Triangle.
            circle.IsOverlapping(triangle);
        }
        private static bool IsOverlapping(Rectangle rectangle, Triangle triangle)
        {
            // Do specialised geometry
            return true;
        }
    }
