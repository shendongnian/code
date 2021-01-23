        static void Main(string[] args)
        {
            string str = "Hello";
            var array = str.ToArray();
            PrintReverse(ref array);
            Console.Read();
            Debug.Assert(array.Length == 0);
        }
        static void PrintReverse(ref char[] Chars)
        {
            Console.Write(Chars[Chars.Length - 1]);
            Array.Resize(ref Chars, Chars.Length - 1);
            if (Chars.Length == 0) return;
            PrintReverse(ref Chars);
        }
