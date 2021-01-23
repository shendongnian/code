    class Program
    {
        static void Main(string[] args)
        {
            Vector2 a = new Vector2(1, 1);
            Vector2 b = new Vector2(3, 1);
            float distance = 0.5f; // From 0.0 to 1.0.
            Vector2 c = (a - b) * distance;
            Console.WriteLine(c);
        }
    }
