    public class Processor<T>
    {
        public K Process<K>() { ... }
    }
    ...
    public Processor<T> CreateProcessor<T> (IEnumerable<T> set)
    {
        return new Processor<T>(set)
    }
    ...
    string result =  CreateProcessor(dataSlice).Process<string>();
