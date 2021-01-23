    [WebService(Namespace = "http://something.cool.com/")]
    [ScriptService] // This is part of the magic
    public class UserManagerService : WebService
    {
        [WebMethod]
        [ScriptMethod] // This is too a part of the magic
        public MyComplexObject MyMethod(MyComplexInput myParameter)
        {
            // Here you make your process, read, write, update the database, sms your boss, send a nuke, or whatever...
 
            // Return something to your awaiting client
            return new MyComplexObject();
        }
    
    }
