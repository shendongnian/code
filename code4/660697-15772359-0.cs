    public abstract class BaseClass<T> where T : BaseClass<T> {
        public object Contents { get; set; }
        public Action<T> Mutator { get; set; }
        public abstract void Initialise();
    }
