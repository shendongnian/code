    private static double MilesToFeet(UnitConverter milesToFeetConverter, ref int done)
            {
    
                double amount;
                Console.WriteLine("Enter a number of miles to be converted to feet.");
                amount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(milesToFeetConverter.Convert(amount) + " feet to said number of miles.");
    
                return amount;
    
            }
