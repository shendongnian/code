    public class BaseClass<T> {
        public Subject<T> Results;
    }
    
    public class ChildA : BaseClass<AssociatedClassA> {
    }
    
    public class ChildB : BaseClass<AssociatedClassB> {
    }
