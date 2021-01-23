    public class SendGetAccountResponseService : Service
    {
        public SendGetAccountNotificationResponse Any(SendGetAccountNotification request)
        {
            Console.WriteLine("Reached");
            return new SendGetAccountNotificationResponse() {Result = "Success for Account " + request.Account.ExternalAccountId};
        }
    }
