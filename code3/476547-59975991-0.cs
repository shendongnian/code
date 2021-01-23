    protected override void OnStart(string[] args)
    {
        try
          {
            ServiceHost myServiceHost = new ServiceHost(typeof(myservice));
            myServiceHost.Opening += OnServiceHostOpening;
            myServiceHost.Open();
    	  }
    	  catch (Exception ex)
    	  {
    	     //handle exception
          }
    }
    
    private void OnServiceHostOpening(object sender, EventArgs e)
    {
       //do something
    }
