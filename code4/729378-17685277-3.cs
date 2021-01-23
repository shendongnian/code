    void Main()
    {
    	Events.Queue(new Message(){ Text = "Hit points +5" });
    	Events.Queue(new Message(){ Text = "Hit points +6" });
    	Events.Queue(new Message(){ Text = "Hit points +7" });
    	
    	while(Events.HasNext())
    	{
    		Console.WriteLine(Events.GetNext().Text);
    	}
    }
    
    public static class Events
    {
    	private static Queue<Message> messages = new Queue<Message>();
    	
    	public static void Queue(Message message)
    	{
    		messages.Enqueue(message);
    	}
    	
    	public static Message GetNext()
    	{
    		return messages.Dequeue();
    	}
    	
    	public static bool HasNext()
    	{
    		return messages.Count > 0;
    	}
    }
    
    public class Message
    {
    	public string Text {get; set;}
    }
