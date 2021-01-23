    void Application_Error(object sender, EventArgs e)
    {
        Exception opException = Server.GetLastError();
        switch (opException.GetBaseException().GetType().Name)
	    {
		    case "OptimisticConcurrencyException":
                            //display a friendly message
                        break;
        }
        Server.ClearError();
    }
