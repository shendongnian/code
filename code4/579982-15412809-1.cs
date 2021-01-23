    class IntMessage : Message
    {
    	public int Value = 100;
    }
    
    class StringMessage : Message
    {
    	public string Value = "a string";
    }
    
    static void Main(string[] args)
    {
    	MessageHandler.Subscribe((StringMessage m) => Console.WriteLine("String : " + m.Value));
    	MessageHandler.Subscribe((StringMessage m) => Console.WriteLine("2nd String : " + m.Value));
    	MessageHandler.Subscribe((IntMessage m) => Console.WriteLine("Int : " + m.Value));
    	MessageHandler.Subscribe((IntMessage m) => Console.WriteLine("2nd Int : " + m.Value));
    
    	MessageHandler.Publish(new IntMessage());
    	MessageHandler.Publish(new StringMessage());
    }
