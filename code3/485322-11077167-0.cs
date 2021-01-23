    //From Windows Service, use this code
    
    
                MessageQueue messageQueue = null;
                if (MessageQueue.Exists(@".\Private$\SomeTestName"))
                {
                    messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                    messageQueue.Label = "Testing Queue";
                }
                else
                {
                    // Create the Queue
                    MessageQueue.Create(@".\Private$\SomeTestName");
                    messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                    messageQueue.Label = "Newly Created Queue";
                }
    
                messageQueue.Send("First ever Message is sent to MSMQ", "Title");
    
    
    //FROM WINDOWS application
    
                messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                messageQueue.Formatter = new XmlMessageFormatter(new string[] { "System.String" });
                // iterating the queue contents
                foreach (Message msg in messageQueue)
                {
                    string readMessage = msg.Body.ToString();
                    //do processing
                }
                // after all processing, delete all the messages
                messageQueue.Purge();
