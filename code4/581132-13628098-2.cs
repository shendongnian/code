        private void ShareLink(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask()
                {
                    Title = "Code Samples",
                    LinkUri = new Uri("http://msdn.microsoft.com/en-us/library/windowsphone/develop/ff431744(v=vs.92).aspx", UriKind.Absolute),
                    Message = "Here are some great code samples for Windows Phone."
                };
            shareLinkTask.Show();
        }
        
        private void ShareEmail(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask()
                {
                    Subject = "message subject",
                    Body = "message body",
                    To = "recipient@example.com",
                    Cc = "cc@example.com",
                    Bcc = "bcc@example.com"
                };
            emailComposeTask.Show();
        }
        private void ShareSMS(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask()
                {
                    Body = "Try this new application. It's great!"
                };
            smsComposeTask.Show();
        }
