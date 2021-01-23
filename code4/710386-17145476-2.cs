    [ServiceBehavior(...)]
    [KnownType(typeof(Message))]
    public class ActiveDirectory : IActiveDirectory
    {
        public AbstractMessage Dummy3()
        {
            return new Message();
        }
    }
