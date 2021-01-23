    public class Indexer<T>
    {
        private T[] _values;
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
        protected override OnValueChanging(float value)
        {
            if (float.IsNaN(value))
                throw new Exception("Blar blar");
        }
    }
    public class Container
    {
        public FloatIndexer Outputs { get; set; }
    }
    ...
    var container = new Container();
    container.Outputs[0] = 2.5f;
    container.Outputs[1] = 0.4f;
    container.Outputs[3] = float.NaN; // BOOM!
    ...
