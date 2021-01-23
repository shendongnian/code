    namespace TypeExample {
        public interface IBase<T> { }
        public interface IDerived<T> : IBase<T> { }
        public interface IDerived2<T> : IDerived<T> { }
        public class Base<T> : IBase<T> { }
        public class Derived<T> : Base<T>, IDerived<T> { }
        public class Derived2<T> : Derived<T>, IDerived2<T> { }
    }
