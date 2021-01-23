    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0, z = 0;
            int x1 = -10, x2 = 10,
                y1 = -10, y2 = 10,
                z1 = -10, z2 = 10;
            for (int ix = x1; ix < x2; ix++)
            {
                for (int iy = y1; iy < y2; iy++)
                {
                    for (int iz = z1; iz < z2; iz++)
                    {
                        var result = (2 * ix) + (5 * iy) + 6 * (Math.Pow(iz, 2));
                        if (result > 0)
                        {
                            Console.WriteLine("x {0} y {1} z {2} : {3}", 
                                ix, iy, iz, result);
                        }
                    }
                }
            }
        }
    }
