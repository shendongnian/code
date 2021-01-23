    abstract class Selectable
    {
        public string Type { get; private set; }
        public Selectable(string type) { Type = type; }
        abstract void doSomething();
    }
