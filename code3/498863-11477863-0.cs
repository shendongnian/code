           System.Messaging.Message msg = new System.Messaging.Message();
            msg.Body = "This is a test message";
            msg.Label = "Test Message";
            msg.Formatter = new ActiveXMessageFormatter();
            MessageQueue queue = new MessageQueue("FormatName:DIRECT=OS:machine2\\Private$\\recievingQueue");
            
            queue.Send(msg);
