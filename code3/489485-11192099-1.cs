    public interface IMockResponseObject<out T>
    {
        T Content { get; }
        DateTime CreationDate { get; set; }
    }
