    public AmazonSentEmailResult SendEmail(string toEmail, string senderEmailAddress, string replyToEmailAddress, string subject, string body)
    {
           List<string> toAddressList = new List<string>();
           toAddressList.Add(toEmail);
           return SendEmail(this.AWSAccessKey, this.AWSSecretKey, toAddressList, new List<string>(), new List<string>(), senderEmailAddress, replyToEmailAddress, subject, body);
    }
    public class AmazonSentEmailResult
    {
        public Exception ErrorException { get; set; }
        public string MessageId { get; set; }
        public bool HasError { get; set; }
        public AmazonSentEmailResult()
        {
            this.HasError = false;
            this.ErrorException = null;
            this.MessageId = string.Empty;
        }
    }
