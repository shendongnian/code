    static void Main()
    {
        double x = ObtainDoubleFromUser(
            "Enter the side length of the cube: ", 
            "Please enter a number: ");
        Console.WriteLine("The volume is {0}", Cube(x));
    }
    static double ObtainDoubleFromUser(string firstMessage, string failureMessage)
    {
        Console.Write(firstMessage);
        while(true)
        {
            double result;
            if (Double.TryParse(Console.Read(), out result))
                return result;
            Console.Write(failureMessage);
        }
    }
    static double Cube(double x)
    {
        return Math.Pow(x, 3);
    }
