    abstract class Printer
    {
        public string Name { get; set; }
        public abstract string Send(string Message);
    }
