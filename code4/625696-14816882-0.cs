    public interface IMessage
    {
        int ID { get; }
        IMessage Parent { get;  }
    }
