    void Main()
    {
    	var x = new int[1];
    	Do(x);
    	Console.WriteLine(x);
    }
    
    void Do (int[] array)
    {
    	array[0] = 1;
    }
