    class RealClass
    {
        ICollection<int> SomeInts { get; set; }
    }
    class MySerializationClass
    {
        private readonly RealClass _wrappedObject;
        public SerializationClass() : this(new RealClass()) { }
        public SerializationClass(RealClass wrappedObject)
        {
            _wrappedObject = wrappedObject;
        }
        public List<T> SomeInts
        {
            get { return new List<T>(_wrappedObject.SomeInts); }
            set { _wrappedObject.SomeInts = value; }
        }
    }
