            static int[] x = { 1, 2, 3, 4 };
            static int z = 10;
            static int c = 20;
            static int v = 30;
            static int b = 40;
    
            static void Main(string[] args)
            {
                //since its static data you can easily update array here
                //x = new int[] { z, c, v, b };
                Console.WriteLine(x[0]);
                Console.ReadLine();
            }
    
            static Program()
            {
                x = new int[4] { z, c, v, b };
    
            }
