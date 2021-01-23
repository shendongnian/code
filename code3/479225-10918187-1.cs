    class BaseClass2<T>
      T : BaseClass1
    {
        public List<T> list { get; set; }
    }
    
    class DerivedClass2 : BaseClass2<BaseClass1>
    {
        public DerivedClass1A objA { get; set; }
        public DerivedClass1B objB  { get; set; }
    }
