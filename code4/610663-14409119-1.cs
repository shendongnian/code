     private void Client_MessageReceived(object sender, MessageEventArgs e)
            {
                //Client only accepts text messages
                var message = e.Message as ScsTextMessage;
                if (message == null)
                {
                    return;
                }
                AppendText(message.Text, false);
                
                //Console.WriteLine("Server sent a message: " + message.Text);
            }
