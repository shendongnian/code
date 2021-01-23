    byte valueA = 255;
    byte valueB = 1;
    byte valueC = (byte)(valueA + valueB);
    
    Console.WriteLine("Without CHECKED: {0} + {1} = {2}", valueA.ToString(), 
    													  valueB.ToString(), 
    													  valueC.ToString());
    
    try
    {
    	valueC = checked((byte)(valueA + valueB));
    	Console.WriteLine("With CHECKED: {0} + {1} = {2}", valueA.ToString(), 
    													   valueB.ToString(), 
    													   valueC.ToString());
    }
    catch (Exception e)
    {
    	Console.WriteLine("With CHECKED: " + e.GetType());
    }
