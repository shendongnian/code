    interface IPart{}
    class Engine : IPart{} 
    
    interface IMachine
    {
        void Produce(IPart part);
        Type Type { get; }
    }
    interface IGenericMachine<in TPart> : IMachine
    {
        void Produce(TPart with);
    }
    class EngineMachine : IGenericMachine<Engine>
    {
        public void Produce(Engine with)
        {
        }
        public void Produce(IPart part)
        {
            if (part.GetType() != typeof(Engine))
                throw new ArgumentException("part must be an Engine");
        }
        public Type Type { get { return typeof (Engine); } }
    }
    internal class MachineLocator
    {
        public Dictionary<Type, IMachine> Machines;
        public IGenericMachine<TPart> GetMachine<TPart>()
        {
            return Machines
                .Select(x => x.Value)
                .OfType<IGenericMachine<TPart>>()
                .Single();
        }
        public IMachine GetMachine(Type type)
        {
            return Machines
                .Where(x => x.Value.Type == type)
                .Select(x=>x.Value)
                .Single();
        }
    }
    class Program
    {
        static public void Main()
        {
            var locator = new MachineLocator();
            locator.Machines.Add(typeof(EngineMachine), new EngineMachine());
            var machineKnown = locator.GetMachine<Engine>();
            var machineUnknown = locator.GetMachine(typeof(Engine));
            machineUnknown.Produce(new Engine());
        }
    }
