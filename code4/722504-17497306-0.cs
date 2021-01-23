    foreach (Contact contact in Contact.LoadWithPredicate(getAll))
    {
    	try
    	{
    		...
    		
    		object[] firstEnumerable = null;
    		object[] secondEnumerable = null;
    		
    		//some logic gates here which under some circumstances do not 
    		//assign a valid instance to firstEnumerable or secondEnumerable
    	
    		...
    		Console.WriteLine(i); //this prints every time
    		
    		//Turn the Enumerables into strings for printing
    		string firstEnumAsString = String.Join(", ", firstEnumerable.ToArray()); //exception here
    		string secondEnumAsString = String.Join(", ", secondEnumerable.ToArray()); //or exception here
    		
    		Console.WriteLine("Email: " + firstString+ ", correspondance: " + secondString+ ", PAM addresses: " + firstEnumAsString+ ", famousPeople: " + secondEnumAsString);
    		...
    	}
    	catch
    	{
    	    //maybe some logging? maybe not?
    	}
    }
