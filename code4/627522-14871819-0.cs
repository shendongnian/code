    public class BaseClass<T> where T : MyBase, new()
    {
        public BaseClass() { }
        protected virtual T WorkField { get { return new T(); } }
        public int WorkProperty { get { return WorkField.Value; } }
    }
    public class DerivedClass : BaseClass<MyBase>
    {
        public DerivedClass() : base() { }
