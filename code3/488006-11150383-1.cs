    string letters = "Hello World";
    Char[] array = letters.ToCharArray();
    
    foreach (Char c in array)
    {
    	if (c == 'o')
    	{
    		Console.ForegroundColor = System.ConsoleColor.Red;
    		Console.Write(c);
    	}
    	else
    	{
    		Console.ForegroundColor = System.ConsoleColor.White;
    		Console.Write(c);
    	}
    }
    Console.WriteLine();
    Console.Read();
