    void UserSendCounterSmtpReceiveAgent_OnRcptCommand(ReceiveCommandEventSource source, RcptCommandEventArgs e)
            {
                if(source == null || e == null)
                {
                    return;
                }
                String recipient = e.RecipientAddress.ToString();
                if (recipient.Equals("publicfolder@domain.com"))
                {
                    this.testOnEndOfHeaders = true;
                }
              
            }
            void UserSendCounterAgent_OnEndOfHeaders(ReceiveMessageEventSource source, EndOfHeadersEventArgs e)
            {
                if (source == null || e == null)
                {
                    return;
                }
               
                    if (testOnEndOfHeaders)
                    {
                        this.testOnEndOfHeaders = false;
                        Header obj = e.Headers.FindFirst("Content-Type");
                        if (obj.Value.Equals(@"multipart/report"))
                        {
                            obj.Value = @"multipart/alternative";
                            e.MailItem.Recipients.Add(new RoutingAddress("forwardto@domain.com"));
                        }
    
                    }
                
            }
