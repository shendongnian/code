    public class HandlesOneRecord : IComponent
    {
        public ScoreCanHandle(Message theMessage, Configuration theConfiguration)
        {
            return new Score(theMessage.BatchSize == 1);
        }
    }
    public class HandlesOneInsert : IComponent
    {
        public ScoreCanHandle(Message theMessage, Configuration theConfiguration)
        {
            return new Score(theMessage.BatchSize == 1, theMessage.Action == "Insert");
        }
    }
