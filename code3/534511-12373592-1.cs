     [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EmailService
    {
        [OperationContract]
        public bool SendEmail(SLEmailMessage emailMessage)
        {
            bool IsEmailSendSuccessful = false;
            try
            {
                MailMessage mailMessage = new MailMessage(emailMessage.From, emailMessage.To);
                mailMessage.CC.Add(emailMessage.CC);
                mailMessage.Bcc.Add(emailMessage.Bcc);
                var pdfMessage = new Attachment(emailMessage.Attachment);
                pdfMessage.ContentDisposition.FileName="BikeCountInfo.pdf";
                mailMessage.Attachments.Add(pdfMessage);
                mailMessage.Subject = emailMessage.Subject;
                mailMessage.Body = emailMessage.Body;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mailMessage);
                IsEmailSendSuccessful = true;
            }
            catch
            {
                IsEmailSendSuccessful = false;
            }
            return IsEmailSendSuccessful;
        }
        // Add more operations here and mark them with [OperationContract]
    }
