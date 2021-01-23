    public abstract class MessageCompleteHandler
    {
        public abstract void Execute();
    }
    
    //name this one better, just an example :)
    public class ListOfStringHandler : MessageCompleteHandler
    {
        public override void Execute()
        {
            //get list of strings
            // do something with it
        }
    }
    public class MessageCompleteHandlerFactory
    {
        public MessageCompleteHandler GetHandler(int transactionId)
        {
            //this replaces/uses your dictionary to match handlers with types.
        }
    }
