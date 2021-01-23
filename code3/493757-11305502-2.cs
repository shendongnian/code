    double posValue = 1234;
    double negValue = -1234; 
    double zeroValue = 0;
    
    string fmt = "+##;-##;**Zero**";
    
    Console.WriteLine("value is positive : " + posValue.ToString(fmt));    
    Console.WriteLine();
    
    Console.WriteLine("value is negative : " +negValue.ToString(fmt));    
    Console.WriteLine();
    
    Console.WriteLine("value is Zero : " + zeroValue.ToString(fmt));
    Console.WriteLine();
