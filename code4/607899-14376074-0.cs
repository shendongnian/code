    [NUnitAddinAttribute(Type = ExtensionType.Core,
    Name = "Database Addin",
    Description = "Writes test results to the database")]
    public class MyExtension :IAddin, EventListener
    {
    //some private attributes to hold important data
    
    //you must provide the Install method
        public bool Install(IExtensionHost host)
        {
            //I also built my connection string in here
            IExtensionPoint listeners = host.GetExtensionPoint("EventListeners");
            if (listeners == null)
                 return false;
            listeners.Install(this);
            return true;
        }
    //you must also provide all the event handlers, 
    //but they don't have to actually do anything if they are not used.
    //e.g.
        public void TestStarted(NUnit.Core.TestName testName)
        {
            //This saved the start time of the test
            _start =  DateTime.Now;
        }
        public void TestFinished(NUnit.Core.TestResult result)
        {
            //LogTest connected to the databse and executed a proc to 
            //insert the log, was quite simple
            LogTest((result.Message == null? "" : result.Message),
                result.ResultState,
                result.Name,
                _start,
                DateTime.Now);
        }
        public void TestOutput(NUnit.Core.TestOutput testOutput)
        {
             //this is one of the unused event handlers, it remains empty.
        }
        //etc..
    }
            
