    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int[] xx = { 4, 5, 4, 3, 2 };
            int findValue = 4;
            var indexes = xx.Select((val, index) => new { Value = val, Index = index })
                .Where(x => x.Value == findValue)
                .Select(x => x.Index);
            foreach (var index in indexes)
                Console.WriteLine(index);
        }
    }
