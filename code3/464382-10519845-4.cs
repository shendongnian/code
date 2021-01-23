    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class MainService : IChat
    {
        IChatCallback ChatCallback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
        //Changed this to be just a declaration. This will be null,
        // as there is no object yet, this is really just a pointer to nothing.
        //This tells the system that you might/are planning to use an object called 
        //chat, but it doesn't exist yet.
        Chat chat;
        
        // Get your default constructor going. This will create the actual chat object, allowing the rest of your class to access it.
        public MainService()
        {
             //instantiate it! (or as some of our co-ops say "We're newing it")
             chat = new Chat(this);
        }
        //now that chat is actually instantiated/created you can use it.
        public void ShowChat()
        {
            chat.Show();
        }
        public void SendInstantMessage(string user, string message)
        {
            chat.RaiseMsgEvents(user, message);
            ChatCallback.InstantMessage(user, message);
        }
     }
---------
    public class bar
    {
        foo test = new foo(this); // will not work
    
        public bar()
        {
            foo f = new foo(this); //will work.            
        }
    }
    
    public class foo 
    {
    
        public foo()
        { }
    
        public foo(bar barAsParameter)
        {
        }
    }
