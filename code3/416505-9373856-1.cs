    static void Main(string[] args)
    {
    	ODBC_Manager odbc = new ODBC_Manager();
    	string dsnName = //Name of the DSN connection here
    
    	if (odbc.CheckForDSN(dsnName) > 0)
    	{
    		Console.WriteLine("\n\nODBC Connection " + dsnName + " already exists on the system");
    	}
    	else
    	{
    		Console.WriteLine("\n\nODBC Connection " + dsnName + " does not exist on the system");
    		Console.WriteLine("\n\nPress 'Y' to create the connection?");
    
    		string cont = Console.ReadLine();
    		if (cont == "Y" || cont == "y")
    		{
    			odbc.CreateDSN(dsnName);
    			Environment.Exit(1);
    		}
    		else
    		{
    			Environment.Exit(1);
    		}
    	}
    }
