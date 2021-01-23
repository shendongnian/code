    static class Test
    {
        public static void AddComplexNumbers()
        {
            // Using the calculator
            var numbers = new Complex[] { new Complex(2, 7), new Complex(6, -2) };
            var result = Caclulator<Complex>.AddValues(numbers);
            Console.WriteLine(result); // ==> (8, 5)
            // Directly
            var c1 = new Complex(2, 7);
            var c2 = new Complex(6, -2);
            result = c1 + c2;
            Console.WriteLine(result); // ==> (8, 5)
        }
    }
