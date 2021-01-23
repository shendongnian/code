    private static void CompareWhichIsBetter(int numTypedDigits)
    {
        Console.WriteLine("Number of typed digits: " + numTypedDigits);
        Random rnd = new Random(DateTime.Now.Millisecond);
        int countDecimalIsBetter = 0;
        int countDirectIsBetter = 0;
        int countEqual = 0;
        for (int i = 0; i < 1000000; i++)
        {
            double origDouble = rnd.NextDouble();
            //Use the line below for the user-typed-in-numbers case.
            //double origDouble = Math.Round(rnd.NextDouble(), numTypedDigits); 
            float x = (float)origDouble;
            double viaFloatAndDecimal = (double)Convert.ToDecimal(x);
            double viaFloat = x;
            double diff1 = Math.Abs(origDouble - viaFloatAndDecimal);
            double diff2 = Math.Abs(origDouble - viaFloat);
            
            if (diff1 < diff2)
                countDecimalIsBetter++;
            else if (diff1 > diff2)
                countDirectIsBetter++;
            else
                countEqual++;
        }
        Console.WriteLine("Decimal better: " + countDecimalIsBetter);
        Console.WriteLine("Direct better: " + countDirectIsBetter);
        Console.WriteLine("Equal: " + countEqual);
        Console.WriteLine("Betterness of direct conversion: " + (double)countDirectIsBetter / countDecimalIsBetter);
        Console.WriteLine("Betterness of conv. via decimal: " + (double)countDecimalIsBetter / countDirectIsBetter );
        Console.WriteLine();
    }
