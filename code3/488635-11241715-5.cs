    class Program
    {
        static void Main(string[] args)
        {
            var pixels = new bool[60,60];
            Console.BufferHeight = pixels.GetLength(1) * 2 + 3;
            EllipseDrawer.Ellipse(pixels, new Rectangle(20, 20, 40, 60));
            PrintMatrix(pixels);
            Console.WriteLine();
            pixels = new bool[60, 60];
            EllipseDrawer.FillEllipse(pixels, new Rectangle(40, 40, 20, 20));
            PrintMatrix(pixels);
            Console.WriteLine();
            Console.ReadLine();
        }
        public static void PrintMatrix(bool[,] matrix)
        {
            var width = matrix.GetLength(0);
            var height = matrix.GetLength(1);
            if(width > Console.BufferWidth)
            {
                Console.BufferWidth = width;
            }
            for (var j = 0; j < height; ++j)
            {
                for (var i = 0; i < width; ++i)
                {
                    Console.Write(matrix[i, j] ? 1 : 0);
                }
             
                if (width < Console.BufferWidth)
                {
                    Console.WriteLine();
                }
            }
        }
    }
