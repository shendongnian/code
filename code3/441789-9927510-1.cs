    public struct Nasty
    {
        public int value;
        public void SetValue()
        {
            value = 10;
        }
    }
    class Test
    {
        static readonly Nasty first;
        static Nasty second;
        static void Main()
        {
            first.SetValue();
            second.SetValue();
            Console.WriteLine(first.value);  // 0
            Console.WriteLine(second.value); // 10
        }
    }
