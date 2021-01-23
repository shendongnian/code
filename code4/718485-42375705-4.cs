    public class MockSMSService :ISMSService
     {
     public void SendSMS(string phoneNumber, string body)
     {
     SaveSMSToFile(phoneNumber,body);
     }
    
    private void SaveSMSToFile(string mobileNumber, string body)
     {
     /*implementation for saving SMS to a file*/
    Console.WriteLine("Mocking SMS using file to mobile: 
    	{0}. SMS body: {1}", mobileNumber, body);
     }
     }
