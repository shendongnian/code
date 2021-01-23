    class TestDelegate
    {
        public static void Main(string[] args)
        {
            // Here is the Code that uses the delegate defined above.
            SampleDelegate sd = delegate(param) {
                            Console.WriteLine("Called me using parameter - " + param);
                        };
            sd.Invoke("FromMain");
        }
    }
