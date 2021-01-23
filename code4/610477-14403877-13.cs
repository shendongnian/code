    private static void Main()
    {
        Rectangle rectangle = new Square();
        rectangle.Height = 2;
        rectangle.Width = 3;
 
        Console.WriteLine("{0} x {1}", rectangle.Width, rectangle.Height);
    }
    // Output: 3 x 2
