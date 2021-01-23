	void Main()
	{
		Madness(new NotImplementedException("1")); //our 'special' case we handle
		Madness(new NotImplementedException("2")); //our 'special' case we don't handle
		Madness(new Exception("2")); //some other error
	}
	
	void Madness(Exception e){
		Exception myGlobalError;
		
		try
		{
			throw e;
		}
		catch (NotImplementedException ex)
		{
			if (ex.Message.Equals("1"))
			{
				Console.WriteLine("handle special error");
			}
			else
			{
				myGlobalError = ex;
				Console.WriteLine("going to our crazy handler");
				goto badidea;
			}
		}
		catch (Exception ex)
		{
			myGlobalError = ex;
			Console.WriteLine("going to our crazy handler");
			goto badidea;
		}
		return;
		
		badidea:
		try{
			throw myGlobalError;
		}
		catch (Exception ex)
		{
			Console.WriteLine("this is crazy!");
		}
	}
	// Define other methods and classes here
