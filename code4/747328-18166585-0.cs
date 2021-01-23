    static void Main()
    {        
    		 Console.WriteLine("Enter any number");
    		 int a = Convert.ToInt32(ConsoleReadLine());
    		 Console.WriteLine("Enter any number");
    		 int b = Convert.ToInt32(ConsoleReadLine());
    		 int c;
    		 Console.WriteLine("Enter 1 to add, 2 to subtract, 3 to multiply and 4 to divide");
    		 int Choice = Convert.ToInt32(Console.ReadLine());
    		 switch (Choice)
    		   case 1:
    				c = add(a,b);
    			   break;
    			 //and so forth.
    }
    
    public static int add(int a, int b)
    {
    	return a + b;
    }
