    [Export(typeof(IOuter))]
    public class MyOuter : IOuter {
        [ImportingConstructor]
        public MyOuter([Import("MySpecialInnerGenericClass", typeof(IGenericInner<,>))]InnerGenericClass<string, int> value) {
            this.Value = value;
        }
        public IInner Value { get; private set; }
    }
    [Export("MySpecialInnerGenericClass", typeof(IGenericInner<,>))]
    public class InnerGenericClass<T, K> : IGenericInner<T, K> {
        public void Say() {
            Console.WriteLine("{0}, {1}", typeof(T), typeof(K));
        }
    } 
