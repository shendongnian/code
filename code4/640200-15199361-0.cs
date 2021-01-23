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
				  // First, handle the case where an exception was thrown.
			  
				  if (ea.Error != null)
				  {
					  //e.Error.Message <-- error object
				  }
				  else if (ea.Cancelled)
				  {
					  // Next, handle the case where the user canceled 
			  
					  // the operation.
			  
					  // Note that due to a race condition in 
			  
					  // the DoWork event handler, the Cancelled
			  
					  // flag may not have been set, even though
			  
					  // CancelAsync was called.
			  
					  // work was cancelled
				  }
				  else
				  {
					  // Finally, handle the case where the operation 
			  
					  // succeeded.
			  
					  // work suceeded
				  }
                                              
            };
    } 
