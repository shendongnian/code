    //this is a class you need to write, see below
    //this way other code can access this variable too
    public MySpecialMailerClass mailer;
    
    [WebMethod] //this may require a include, you're on your own for that 
                //for now (System.Web.Services)
    public void StartEmails(){
      //do some stuff here to start the email process?
      //create a class that can run the db scripts uninterrupted, 
      //and provide it a public member that can be accessed for the current
      //count, and the expected max count (set to -1 on init so you know 
      //that you haven't finished initting this yet)
      
      mailer = new MySpecialMailerClass();
      new Thread( mailer.Start ) { IsBackground = true }.Start( );
    }
    
    [WebMethod]
    public int GetMaxCount(){
      return mailer.MaxCount;
    }
    
    [WebMethod]
    public int GetCurrentCount(){
      return mailer.CurrentCount;
    }
