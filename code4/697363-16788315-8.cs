    public void CheckIfInt(object ob)
    {
    	if(ob.GetType() == typeof(int))
    	{
    		Console.WriteLine("got an int! Initiate destruction of Universe!");
    	}
    	else
    	{
    		Console.WriteLine("not an int");
    	}
    }
