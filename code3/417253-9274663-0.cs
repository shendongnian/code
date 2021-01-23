    static void Main(string[] args)
    {
        var retVal = 0.0;
        var sum = 0.0;
        while (true) 
        {
            Console.WriteLine("Enter input:");  
            string line = Console.ReadLine();  
            if (line == "exit")  
            {
                break;
            }
    
    
            double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out retVal);
            sum += retVal;
    
            Console.WriteLine(string.Format("Double Value : {0}", sum ));  
        }
    
        Console.ReadKey();
    }
