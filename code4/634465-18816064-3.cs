     public static void Rotate1(ref string str, int n)
        {
            if (n < 1)
                throw new Exception("Negative number for rotation"); ;
            if (str.Length < 1) throw new Exception("0 length string");
            if (n > str.Length)
            {
                n = n % str.Length;
            }
            str = String.Concat(str.Skip(n).Concat(str.Take(n)));
        }
