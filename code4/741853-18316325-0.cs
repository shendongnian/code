    class InternalSqm 
    {
       //constructor
       public InternalSqm ()
       {
          //...
          //Catch domain shutdown (Hack: frantically look for things we can catch)
          if (AppDomain.CurrentDomain.IsDefaultAppDomain())
             AppDomain.CurrentDomain.ProcessExit += MyTerminationHandler;
          else
             AppDomain.CurrentDomain.DomainUnload += MyTerminationHandler;
       }
       private void MyTerminationHandler(object sender, EventArgs e)
       {
          //The domain is dying. Serialize out our values
          this.Dispose();
       }
       ...
    }
