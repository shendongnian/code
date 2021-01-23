    static void Method(int value = 1, string name = "Perl")
    {
	     Console.WriteLine("value = {0}, name = {1}", value, name);
    }
    
        Method(); //prints 1, Perl
    
    	
    	Method(4);//prints 4, perl
    
    	
        Method("Dot"); // prints 1, Dot
    
    	
    	Method(4, "Dot"); //prints 4, Dot
