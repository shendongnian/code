    interface IPart{}
    class Engine : IPart{}
    class SuperEngine : Engine{}
    interface IMachine
    {
        Type Type { get; }
    }
    interface IFactoryMachine<in TPart> : IMachine
    {
        void Produce(TPart with);
    }
    class EngineMachine : IFactoryMachine<Engine>
    {
        public void Produce(Engine with){}
        public Type Type { get { return typeof (Engine); } }
    }
    class SuperEngineBuilder : IFactoryMachine<SuperEngine>
    {
        public void Produce(SuperEngine with) { }
        public Type Type { get { return typeof(Engine); } }
    }
