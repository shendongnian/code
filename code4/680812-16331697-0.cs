    static void Main(string[] args)
            {
                checked
                {
                    int A = 9;
                    int enc = (int)(Math.Pow(A, e) % n);
                    int dec = (int)(Math.Pow(enc, d) % n);
                    Console.WriteLine(A);
                    Console.WriteLine(enc);
                    Console.WriteLine(dec);
                }
            }
