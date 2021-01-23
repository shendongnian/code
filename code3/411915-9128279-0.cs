    using System;
    
    public delegate string MessageFormatterDelegate
        (string message, params object[] arguments);
    public delegate string MessageFormatterCallback
        (MessageFormatterDelegate formatterDelegate);
    
    public static class TestClass
    {
        public static string Evaluate(MessageFormatterCallback formatterCallback)
        {
            return (formatterCallback(String.Format));
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            string text = TestClass.Evaluate
                (message => message("{0},{1},{2}", 1, 2, 3));
            Console.WriteLine(text);
        }
    }
