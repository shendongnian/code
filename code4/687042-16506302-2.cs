    public class Indexer<T>
    {
        private T[] _values;
        public Indexer(int capacity)
        {
            _values = new T[capacity];
        }
        protected virtual void OnValueChanging(T value)
        {
            // do nothing
        }
    
        public T this[int index]
        {
            get { return _values[index]; }
            set
            {   
                OnValueChanging(value);
                _values[index] = value;
            }
        }
    }
    public class FloatIndexer : Indexer<float>
    {
        public FloatIndexer(int capacity)
            : base(capacity)
        {
        }
        protected override void OnValueChanging(float value)
        {
            if (float.IsNaN(value))
                throw new Exception("Blar blar");
        }
    }
    public class Container
    {
        public Container()
        {
            Outputs = new FloatIndexer(3);
        }
    
        public FloatIndexer Outputs { get; private set; }
    }
    ...
    var container = new Container();
    container.Outputs[0] = 2.5f;
    container.Outputs[1] = 0.4f;
    container.Outputs[2] = float.NaN; // BOOM!
    ...
