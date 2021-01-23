    public static class Email
    {
        private static string _senderEmailAddress = "sendermailadress";
        private static string _senderPassword = "senderpassword";
    
        public static void SendEmail(string receiverEmailAddress, string subject, string body)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(_senderEmailAddress, _senderPassword),
                    EnableSsl = true
                };
                client.Send(_senderEmailAddress, receiverEmailAddress, subject, body);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception sending email." + Environment.NewLine + e);
            }
        }
    }
