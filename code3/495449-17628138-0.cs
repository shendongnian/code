    class Program
    {
        static void Main(string[] args)
        {
            //Note how I don't bother to use a variable?
            //This is a nasty hack that knows the compiler will intern the value.
            //One of the many downsides of hacking the BCL.
            while (string.IsNullOrWhiteSpace(Console.ReadLine()))
            {
                Console.WriteLine("he\0llo");  
                "he\0llo".ReverseInPlace();
            }
        }
    }
    
    public static class Helper
    {
        //Does not support multi-char values.
        public static unsafe void ReverseInPlace(this string str)
        {
            fixed (char* pfixed = str)
                for (int i = 0, ii = str.Length - 1; i < str.Length / 2; i++, ii--)
                {
                    var p1 = (char*)pfixed + i;
                    var p2 = (char*)pfixed + ii;
                    var temp = *p1;
                    *p1 = *p2;
                    *p2 = temp;
                }
        }
    }
