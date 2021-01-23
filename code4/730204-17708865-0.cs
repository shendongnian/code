    void Main()
    {
    	var input = Console.ReadLine();
    	int phone;
    	while(!int.TryParse(input, out phone)){
    		Console.WriteLine("Please enter a number");
    		input = Console.ReadLine();
    	}
    	
    	Console.WriteLine("Success");
    }
