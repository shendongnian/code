        static double Round(double input, double errorDesired)
        {
            if (input == 0.0) 
                return 0.0;
            for (int decimals = 0; decimals < 17; ++decimals)
            {
                var output = Math.Round(input, decimals);
                var errorAchieved = Math.Abs((output - input) / input);
                if (errorAchieved <= errorDesired)
                    return output;
            }
            return input;
        }
    }
        static void Main(string[] args)
        {
            foreach (var input in new[] { 0.13999, 0.0079996, 0.12345 })
            {
                Console.WriteLine("{0} -> {1}         (.1%)", input, Round(input, 0.001));
                Console.WriteLine("{0} -> {1}         (1%)", input, Round(input, 0.01));
                Console.WriteLine("{0} -> {1}         (10%)", input, Round(input, 0.1));
            }
        }
