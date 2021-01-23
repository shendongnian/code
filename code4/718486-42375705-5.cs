    public class UIHandler
     {
     private readonly ISMSService _SMSService;
    
    public UIHandler(ISMSService SMSService)
     {
     _SMSService = SMSService;
     }
     public void SendConfirmationMsg(string mobileNumber) {
    
     _SMSService.SendSMS(mobileNumber, "Your order has been shipped successfully!");
     }
     }
  
