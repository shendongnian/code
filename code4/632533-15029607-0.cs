      public override void Run()
        {
            while (!IsStopped)
            {
                try
                {
                    // Receive the message
                    BrokeredMessage receivedMessage = null;
                    receivedMessage = Client.Receive();
                    if (receivedMessage != null)
                    {
                        // Process the message
                        receivedMessage.Complete(); // Unless you do this the message goes back in the Queue
                    }
                }
                catch (MessagingException e)
                {
                    if (!e.IsTransient)
                    {
                        Trace.WriteLine(e.Message);
                        throw;
                    }
                    Thread.Sleep(10000); // optional if you want to add a delay
                }
            }
        }
