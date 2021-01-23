    public interface ITypelist { Type[] List { get; } }
    public class Typelist<T1> : ITypelist {
        public Type[] List { get { return new Type[]{typeof(T1)}; }}
    }
    public class Typelist<T1, T2> : ITypelist {
        public Type[] List { get { return new Type[]{typeof(T1), typeof(T2)}; }}
    }
    // etc
