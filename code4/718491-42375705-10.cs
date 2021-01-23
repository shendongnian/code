    public class SMSService : ISMSService
     {
     public void SendSMS(string mobileNumber, string body)
     {
     SendSMSUsingGateway(mobileNumber, body);
     }
  
    private void SendSMSUsingGateway(string mobileNumber, string body)
     {
     /*implementation for sending SMS using gateway*/
    Console.WriteLine("Sending SMS using gateway to mobile: 
    	{0}. SMS body: {1}", mobileNumber, body);
     }
     }
  
