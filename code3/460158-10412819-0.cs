    namespace Apache.NMS.Test
    {
	[TestFixture]
	public class RequestResponseTest : NMSTestSupport
	{
		protected static string DESTINATION_NAME = "RequestDestination";
		
		[Test]
		[Category("RequestResponse")]		
		public void TestRequestResponseMessaging()
		{
			using(IConnection connection = CreateConnection())
			{
				connection.Start();
				using(ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
				{
					IDestination destination = SessionUtil.GetDestination(session, DESTINATION_NAME);
					ITemporaryQueue replyTo = session.CreateTemporaryQueue();
					using(IMessageConsumer consumer = session.CreateConsumer(destination))
					using(IMessageProducer producer = session.CreateProducer(destination))
					{
						IMessage request = session.CreateMessage();
						
						request.NMSReplyTo = replyTo;
						
						producer.Send(request);
						
						request = consumer.Receive(TimeSpan.FromMilliseconds(3000));
						Assert.IsNotNull(request);
						Assert.IsNotNull(request.NMSReplyTo);
						
						using(IMessageProducer responder = session.CreateProducer(request.NMSReplyTo))
						{
							IMessage response = session.CreateTextMessage("RESPONSE");							
							responder.Send(response);
						}						
					}
					
					using(IMessageConsumer consumer = session.CreateConsumer(replyTo))
					{
						ITextMessage response = consumer.Receive(TimeSpan.FromMilliseconds(3000)) as ITextMessage;
						Assert.IsNotNull(response);
						Assert.AreEqual("RESPONSE", response.Text);
					}
				}
			}
		}
	}
}
