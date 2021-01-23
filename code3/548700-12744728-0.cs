    public void GetEmployee(int id, Action<Employee> getEmployeeCompletedHandler)
    {
    	Task<Employee> t = new Task<Employee>(()=>client.GetEmployee(id));    
    	t.Start();
    	t.ContinueWith(task=>
    	{
    		if (getEmployeeCompletedHandler != null)
    			getEmployeeCompletedHandler(t1.Result);
    	});
    }
