    ....
    public static string PID_1 = "12";
    public static string PID_2 = "13";
    public static string PID_3 = "14";
    
    
    
    // Define other methods and classes here
    
    void Main()
    {
       var dict = new Dictionary<string, Action>
       {
     	{PID_1, ()=>Console.WriteLine("one")},
    	{PID_2, ()=>Console.WriteLine("two")},
    	{PID_3, ()=>Console.WriteLine("three")},
       };
       var pid = PID_1;
       dict[pid]();	
    }
