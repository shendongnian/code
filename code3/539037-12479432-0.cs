    static void Main()
    { 
        string messageForDbaseParam="Enter the base: ";
        double dbase = GetDouble(messageForDbaseParam);
        string messageForExpParam ="enter the exponent: ";
        double exp = GetDouble(messageForExpParam);
        Console.WriteLine("{0} to the power of {1} is {2}", dbase, exp, Math.Pow(dbase, exp));
    }
    static double GetDouble(string prompt)
    {
        double value = Double.NaN;
        Boolean incorrectValue=true;
        while(incorrectValue)
        {
            Console.Write(prompt);
            try
            {
                value = Double.Parse(Console.ReadLine());
                incorrectValue=false;
            }
            catch 
            {
                Console.WriteLine("error");
            }
        }        
        return value;
    }
    
