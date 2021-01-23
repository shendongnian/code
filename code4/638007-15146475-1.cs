    [Serializable]
    public class Inserted<T> : IInstantiable<T>
        where T : IInstantiable<T>
    {
        public Inserted() { }
        public Inserted(T t)
        {
            this.CopyFrom(t);
        }
    }
