    public bool function()
    {
       bool doesExist = false;          
       BackgroundWorker worker = new BackgroundWorker();
       worker.DoWork += (o, ea) =>
                {
                     // do some work
                     ea.Result = true; // set this as true if all goes well!
                };
        worker.RunWorkerCompleted += (o, ea) =>
            {
				  // since the boolean value is calculated here &
				  // RunWorkerCompleted returns void
				  // you can create a method with boolean parameter that handle the result.
				  Another_Way_To_Return_Boolean(doesExist)
                                              
            };
    } 
    private void Another_Way_To_Return_Boolean(bool result)
    {
		if (result)
		{
		
		}
    }
