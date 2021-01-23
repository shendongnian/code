                for (int i = messageCount; i > 0; i--)
                {
                    var msg = client.GetMessage(i);
                    if (verifiedEmail.Contains(msg.Headers.From.Address) 
                        || verifiedSms.Contains(msg.Headers.From.Address))
                    {
                        string tempMessage = msg.ToMailMessage().Body.ToLower();
                        if (tempMessage.Contains("cmd") && tempMessage.Contains("fin"))
                        {
                            allMessages.Add(msg);
                        }
                    }
                    client.DeleteMessage(i);
                }
