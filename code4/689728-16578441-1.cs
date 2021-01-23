    public abstract class ConsoleModule
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public abstract void Execute();
    }
