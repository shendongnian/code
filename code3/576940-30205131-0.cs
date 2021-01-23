    public static class MathDecimals
    {
        public static int GetDecimalPlaces(decimal n)
        {
            n = Math.Abs(n); //make sure it is positive.
            n -= (int)n;     //remove the integer part of the number.
            var decimalPlaces = 0;
            while (n > 0)
            {
                decimalPlaces++;
                n *= 10;
                n -= (int)n;
            }
            return decimalPlaces;
        }
    }
----------
    private static void Main(string[] args)
    {
        Console.WriteLine(1/3m); //this is 0.3333333333333333333333333333
        Console.WriteLine(1/3f); //this is 0.3333333
        Console.WriteLine(MathDecimals.GetDecimalPlaces(0.0m));                  //0
        Console.WriteLine(MathDecimals.GetDecimalPlaces(1/3m));                  //28
        Console.WriteLine(MathDecimals.GetDecimalPlaces((decimal)(1 / 3f)));     //7
        Console.WriteLine(MathDecimals.GetDecimalPlaces(-1.123m));               //3
        Console.WriteLine(MathDecimals.GetDecimalPlaces(43.12345m));             //5
        Console.WriteLine(MathDecimals.GetDecimalPlaces(0));                     //0
        Console.WriteLine(MathDecimals.GetDecimalPlaces(0.01m));                 //2
        Console.WriteLine(MathDecimals.GetDecimalPlaces(-0.001m));               //3
        Console.WriteLine(MathDecimals.GetDecimalPlaces((decimal)-0.00000001f)); //8
        Console.WriteLine(MathDecimals.GetDecimalPlaces((decimal)0.0001234f));   //7
        Console.WriteLine(MathDecimals.GetDecimalPlaces((decimal)0.01f));        //2
        Console.WriteLine(MathDecimals.GetDecimalPlaces((decimal)-0.01f));       //2
    }
