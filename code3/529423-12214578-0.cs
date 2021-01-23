    static void Main(string[] args)
            {
                double[] a = new double[]{
                    13.1,13.2,13.3D,13.4,13.5,13.6,13.7,13.8,13.9,13.58,13.49,13.55,
                };
                foreach (var b in a)
                {
                    Console.WriteLine("{0}-{1}",b,b % 0.5 == 0 ? b : Math.Round(b));
                }
                Console.ReadKey();
            }
