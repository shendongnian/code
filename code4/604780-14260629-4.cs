    class Program
    {
        static void Main(string[] args)
        {
            ArrayList values = new ArrayList()
            {
                "A","AA","B","BB","C","CC"
            };
            SortAlphabetLength alphaLen = new SortAlphabetLength();
            values.Sort(alphaLen);
            foreach (string itm in values)
                Console.WriteLine(itm);
        }
    }
