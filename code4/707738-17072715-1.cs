        public interface IWorker 
        { 
            string MyProperty { get; }
        }
        public interface IWorker<T> : IWorker
        {
            ...
        }
