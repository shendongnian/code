    public static void Main(string[] args)
    {            
        int result = 1;  
        int numToCheck = 141234;
        boolean found = false;
        for (int i = 0; i < 15; i++)
        {          
            if (numToCheck == result)
                found = true;
            result *= 2;
        }  
        if(found) Console.WriteLine("Awesome");
    }
