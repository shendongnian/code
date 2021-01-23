    namespace FindTheArea
    {
    
        class Program
        {
    
            static void Main(string[] args)
            {
                double Height;
                double Width;
                double Area;
    
                Console.WriteLine("Find The Area");
                Console.WriteLine("Please enter the height below");
                Height = double.Parse(Console.ReadLine());
                Console.WriteLine("Please enter the Width below");
                Width = double.Parse(Console.ReadLine());
    
                Console.Clear();
   
                Area = (Height * Width);
    
                Console.WriteLine("The area is...");
                Console.WriteLine();
                Console.WriteLine(Area+"cm2");
    
                Console.ReadKey();
            }
    
        }
    
    }
