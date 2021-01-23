    public class ViewModelProxyFactory<T> : Provider<T>
    {
        public ViewModelProxyFactory(Bar bar) { this.bar = bar; }
        public T CreateInstance(IContext ctx)
        {
            return putYourFactoryCodeHere
        }
    }
    Bind<Foo>().ToProvider<ViewModelProxyFactory<Foo>>();
