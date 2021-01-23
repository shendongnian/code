    public interface Covariant<out T>
    {
        T FunctionReturningT();
    }
    public class MyInterfaceImplementation<T> : Covariant<T>
    {
        public T FunctionReturningT() { /* Blah Blah */ }
    }
