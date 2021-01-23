    string line = Console.ReadLine(); 
    int value;
	if (int.TryParse(line, out value)) 
	{
	    Console.WriteLine("Integer here!");
	}
	else
	{
	    Console.WriteLine("Not an integer!");
	}
