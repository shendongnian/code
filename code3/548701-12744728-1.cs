    public Employee GetEmployee(int id)
    {
    	Task<Employee> t = new Task<Employee>(()=>client.GetEmployee(id));    
    	t.Start();
    	
    	try
    	{
    		t.Wait();
    	}
    	catch (AggregateException ex)
    	{
    		throw ex.Flatten();
    	}
    	
    	return t.Result;
    }
