    public class HandlesOneRecord : IComponent
    {
        public Score CanHandle(Message theMessage, Configuration theConfiguration)
        {
            return new Score(theMessage.BatchSize == 1);
        }
    }
    public class HandlesOneInsert : IComponent
    {
        public Score CanHandle(Message theMessage, Configuration theConfiguration)
        {
            return new Score(theMessage.BatchSize == 1, theMessage.Action == "Insert");
        }
    }
