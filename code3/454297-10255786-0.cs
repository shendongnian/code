    try
    {
    	Console.WriteLine("Inside the Try");
    	goto MyLabel;
    }
    finally
    {
    	Console.WriteLine("Inside the Finally");
    }
    
    MyLabel:
    	Console.WriteLine("After the Label");
