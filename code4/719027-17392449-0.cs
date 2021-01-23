            static int[] x = { 1, 2, 3, 4 };
            static int z = 10;
            static int c = 20;
            static int v = 30;
            static int b = 40;
    
            static void Main(string[] args)
            {
                Console.WriteLine(x[0]);
                Console.ReadLine();
            }
    
            static Program()
            {
                x = new int[4] { z, c, v, b };
    
            }
