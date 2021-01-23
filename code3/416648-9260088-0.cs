    public static void Main(string[] args)
    {            
        int result = 1;  
        int numToTest = 0;
        if ( int.TryParse (args[0], out numToTest) )
        {
           result = (from c in Convert.ToString (numToTest, 2) where c == '1').Count();
        }
        Console.WriteLine(result);
    }
