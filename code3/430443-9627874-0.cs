    // no usings at all
    static class DumbLinq
    {
        static int Select(this int i, System.Func<int, int> f)
        {
            // actually, our Select is a negation operator in disguise
            return -i;
        }
        static void Main()
        {
            int i = 10;
            var j = from n in i
                    select n;
            System.Console.WriteLine(j); // prints -10
        }
    }
