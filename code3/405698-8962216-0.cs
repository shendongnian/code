    public class LeadService : System.Web.Services.WebService {
    [WebMethod(EnableSession = true)]
    public string MyService(string TheIncomingData)
    {
             MyClass TheClass = new MyClass();
             try{
                return TheClass.MyMethod(TheIncomingData);
             }
             catch(Exception ex){
                //handle your exception, log, etc.
             }                
            return "";                 
        }
}
