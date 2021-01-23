    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Console");
            // Reproduce the Unit Test
            var classToTest = new ClassToTest();
            var expected = 42;
            var actual = classToTest.MeaningOfLife();
            Console.WriteLine($"Pass: {expected.Equals(actual)}, expected={expected}, actual={actual}");
        }
    }
