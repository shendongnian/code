    static void Main(string[] args)
    {
    	double[] numbers = new double[10];
    
    	int i = 0;
    	while (i < 10)
    	{
    		double num;
    
    		Console.WriteLine("Enter a number");
    		string input = Console.ReadLine();
    		try
    		{
    			num = double.Parse(input);
    			numbers[i] = num;
    			i++
    		}
    		catch
    		{
    			Console.WriteLine("Invalid Number");
    		}
    	}
    
    	foreach (double d in numbers)
    		Console.WriteLine(d);
    	Console.ReadLine();
    }
