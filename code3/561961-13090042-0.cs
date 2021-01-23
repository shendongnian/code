    class Program
        {
            public static List<Bitmap> Bitmaps = new List<Bitmap>(); 
    
            static void Main(string[] args)
            {
                Bitmaps.Add((Bitmap) Image.FromFile(@"C:\\image.bmp")); // the size of image 23 mb (in that case), you will see in task manager that you app start consumes a lot of memory
                Console.WriteLine("Memory state after loading image in list");
                Console.ReadKey();
                Bitmaps.RemoveAt(0);
                GC.Collect();
                Console.WriteLine("Memory after collect"); // and after deletion from list and start gc you will see that your app consume  less memory
                Console.ReadKey();
            }
        }
