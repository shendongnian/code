	public static class MessagePrinter
	{
		public static void PrintMessage(IMessage message)
		{
			Console.WriteLine(message.GetMessage());
		}
	}
	public interface IMessage
	{
		public string GetMessage();
	}
	public class XMLMessage : IMessage
	{
		public string GetMessage()
		{
			return "This is an XML Message";
		}
	}
	public class SOAPMessage : IMessage
	{
		public string GetMessage()
		{
			return "This is a SOAP Message";
		}
	}
