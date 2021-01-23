    // 1) Objects:
    
    object obj = null;
    
    //string valX1 = obj.ToString();           // throws System.NullReferenceException !!!
    string val1 = Convert.ToString(obj);    
    
    Console.WriteLine(val1 == ""); // True
    Console.WriteLine(val1 == null); // False
    
    			
    // 2) Strings
    
    String str = null;
    //string valX2 = str.ToString();    // throws System.NullReferenceException !!!
    string val2 = Convert.ToString(str); 
    
    Console.WriteLine(val2 == ""); // False
    Console.WriteLine(val2 == null); // True            
    			
    
    // 3) Nullable types:
    
    long? num = null;
    string val3 = num.ToString();  // ok, no error
    
    Console.WriteLine(num == null); // True
    Console.WriteLine(val3 == null); // False 
    Console.WriteLine(val3 == "");  // True
    
    val3 = Convert.ToString(num);  
    
    Console.WriteLine(num == null);  // True
    Console.WriteLine(val3 == null); // False
    Console.WriteLine(val3 == "");  // True
