     enum Alphabets { a = 1, b, c, d, e, f, g, h , i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z }
    
            public static void Main(String[] args)
            {
                string s = Console.ReadLine();
    
                foreach (char c in s)
                {
                    Alphabets parsed = (Alphabets)Enum.Parse(typeof(Alphabets), c.ToString());
                     Console.WriteLine((int)parsed);
                }
    
                Console.ReadKey();
            }
