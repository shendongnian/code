    public interface IInjectedObject
    {
        // Your implementation must raise this event
        // whenever the property changes
        event EventHandler MyImportantPropertyChanged;
        bool MyImportantProperty { get; }
    }
