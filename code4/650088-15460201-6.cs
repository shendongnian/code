    class MyWorker
    {
        private IFactoryMachine<Engine> _engineMachine;
        public MyWorker(IFactoryMachine<Engine> engineMachine)
        {
            _engineMachine = engineMachine;
        }
        public void RunOrderWith(Engine engine)
        {
            _engineMachine.Produce(engine);
        }
    }
    class Program
    {
        static public void Main()
        {
            var IoC = new StandardKernel();
            IoC.Bind<IFactoryMachine<Engine>>().To<EngineMachine>().InSingletonScope();
            IoC.Bind<IFactoryMachine<SuperEngine>>().To<SuperEngineMachine>().InSingletonScope();
            IoC.Bind<MyWorker>().ToSelf();
            var worker = IoC.Get<MyWorker>();
            worker.RunOrderWith(new Engine());
        }
    }
