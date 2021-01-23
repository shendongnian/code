    public class YourTuple
    {
        public ModifierKeys ModifierKey { get; set; }
        public ICommand Command { get; set; }
    }
    
    public class YourClass : Dictionary<YourTuple, ICommand>
