    [Export(typeof(IGenericInner<,>))]
    [Export(typeof(InnerGenericClass<,>))]
    public class InnerGenericClass<T, K> : IGenericInner<T, K> {
        public void Say() {
            Console.WriteLine("{0}, {1}", typeof(T), typeof(K));
        }
    }
