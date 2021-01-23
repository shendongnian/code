    Form2()
    {
    	Application.Idle += Application_Idle;
    }
    
    void Application_Idle(object sender, EventArgs e)
    {
    	throw new NotImplementedException();
    }	
    
    protected override void Dispose(bool disposing)
    {
    	if (disposing)
    	{
    		Application.Idle -= Application_Idle;
    	}
    }
