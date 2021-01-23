    public class MailBox : IMailBox
    {
        public IEnumerable<MailItem> GetItems(string smtpAddress, WellknownFolderName folder)
        {
            var service = new ExchangeService();
            // Some code here...
        }
    }
