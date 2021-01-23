    public SendEmailResult SendEmail(ArrayList toemail, string subject, string bodystring, Enums.EmailTypes emailtype)
        {
            var awsConfig = new AmazonSimpleEmailServiceConfig
                               {
                                   UseSecureStringForAwsSecretKey = true
                               };
            var awsClient = new AmazonSimpleEmailServiceClient(RoleEnvironment.GetConfigurationSettingValue("AwsAccessKeyId"),
                                                               RoleEnvironment.GetConfigurationSettingValue("AwsSecretKey"),
                                                               awsConfig);
           
            //EXAMPLE
            var to = new ArrayList
                               {
                                   "email1@example.com",
                                   "email2@example.com",
                                   "email3@example.com"
                               };
            var dest = new Destination();
            
            dest.WithToAddresses((string[]) to.ToArray(typeof (string)));
            var body = new Body
                            {
                                Html = new Content(bodystring)
                            };
            string fromemail=string.Empty;
            switch (emailtype)
            {
                case Enums.EmailTypes.Notification:
                    fromemail = "notification@example.com";
                    break;
                case Enums.EmailTypes.Support:
                    fromemail = "support@example.com";
                    break;
            }
            
            var title = new Content(subject);
            var message = new Message(title, body);
            var ser = new SendEmailRequest(fromemail, dest, message);
            SendEmailResponse seResponse = awsClient.SendEmail(ser);
           
            return seResponse.SendEmailResult;
        }
