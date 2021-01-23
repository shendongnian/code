    public class SMSService : ISMSService
     {
     private readonly INotifierService _NotifierService;
    
    public SMSService(INotifierService NotifierService)
     {
     _NotifierService = NotifierService;
     }
    
    public void SendSMS(string mobileNumber, string body)
     {
     SendSMSUsingGateway(mobileNumber, body);
     _NotifierService.NotifyByEmail(mobileNumber, body);
     }
    
    private void SendSMSUsingGateway(string mobileNumber, string body)
     {
     /*implementation for sending SMS using gateway*/
    
    Console.WriteLine("Sending SMS using gateway to mobile: 
    	{0}. SMS body: {1}", mobileNumber, body);
     }
     }
  
