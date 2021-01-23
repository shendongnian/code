    static void Main()
        {
    	// Convert string to number.
    	string text = "123";
    	int num = -1;
          if( int.TryParse (text,out num))
    	Console.WriteLine(num);
        }
