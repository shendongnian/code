    public abstract class Command
    {
        public IDocumentSession DocumentSession { get; set; }
        public Setting ContextSetting { get; set; }
        public abstract void Execute();
    }
    public abstract class Command<T> : Command
    {
        public T Result { get; protected set; }
    } 
