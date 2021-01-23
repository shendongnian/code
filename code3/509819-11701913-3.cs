    static class Test
    {
        public static void AddComplexNumbers()
        {
            var numbers = new Complex[] { new Complex(2, 7), new Complex(6, -2) };
            var result = Caclulator<Complex>.AddValues(numbers);
            Console.WriteLine(result); // ==> (8, 5)
        }
    }
