        public  void ReceiveMessage()
		{
			// Connect to the a on the local computer.
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
			// Set the formatter to indicate body contains an Order.
			myQueue.Formatter = new XmlMessageFormatter(new Type[]
				{typeof(String)});
			
			try
			{
				// Receive and format the message. 
				Message myMessage1 = myQueue.Receive();
				Message myMessage2 = myQueue.Receive();
			}
			
			catch (MessageQueueException)
			{
				// Handle sources of any MessageQueueException.
			}
			// Catch other exceptions as necessary.
			finally
			{
				// Free resources.
				myQueue.Close();
			}
			return;
		}
