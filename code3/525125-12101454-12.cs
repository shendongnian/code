    private static void MakeConversion(UnitConverter customConverter)
            {
                Console.WriteLine("Enter a number of {0} to be converted to {1}.",customConverter.From, customConverter.To);
                double amount = Convert.ToDouble(Console.ReadLine());
                string message = string.Format("{0} {1} to said number of {2}", amount, customConverter.To, customConverter.From);
                Console.WriteLine(message);
            }
