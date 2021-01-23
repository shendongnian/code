    while(true)
    {
       string inValue = Console.ReadLine();
       if(String.IsNullOrEmpty(inValue)) break;
    
       values[Convert.ToInt32(inValue)]++; //Bounds checking would be nice here
    }
