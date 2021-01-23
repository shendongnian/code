        class Program
    {
        static void Main(string[] args)
        {
            var test = new EnumTest();
            test.ConsumeEnumerable2Times();
            Console.ReadKey();
        }
    }
    public class EnumTest
    {
        public IEnumerable<int>  CountTo10()
        {
            for (var i = 0; i <= 10; i++)
                yield return i;
        }
        public void ConsumeEnumerable2Times()
        {
            var enumerable = CountTo10();
            foreach (var n in enumerable)
            {
                foreach (int i in enumerable)
                {
                    Console.WriteLine("Outer: {0}, Inner: {1}", n, i);
                }
            }
        }
    }
