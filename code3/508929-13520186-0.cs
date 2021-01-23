    Bind<IA>().To<A1>();
    Bind<IA>().To<A2>().Named("SecondImpl");
    Bind<B>().ToProvider<BProvider>();
    class BProvider : Provider<B>
    {
        IA _a;
    
        public BProvider([Named("SecondImpl")]IA a) { _a=a; }
    
        protected override B CreateInstance(IContext context) { return new B(_a); }
    }
