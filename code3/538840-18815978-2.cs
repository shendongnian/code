    public static void Rotate(ref string str, int n)
        {
            if (n < 1)
                throw new Exception("Negative number for rotation"); ;
            if (str.Length < 1) throw new Exception("0 length string");
            if (n > str.Length) // If number is greater than the length of the string then take MOD of the number
            {
                n = n % str.Length;
            }
            StringBuilder s1=new StringBuilder(str.Substring(n,(str.Length - n)));
            s1.Append(str.Substring(0,n));
            str=s1.ToString();
             
        }
    ///You can make a use of Skip and Take functions of the String operations
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
