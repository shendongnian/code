public class EmailTestImplemtation : IEmailReceived {
   void EmailReceived(EmailResponse message, int messgID) {
      Console.out.WriteLine("Message: " + message.toString() + " MessageID: " + messgID);
   }
}
