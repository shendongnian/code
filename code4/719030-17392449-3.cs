        class Program
        {
            private static Program MyInstance = new Program();
            int[] y = { 5, 6, 7, 8 };
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
    
            public Program()
            {
                Console.WriteLine(y[0]);
            }
    
        }
