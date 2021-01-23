    class MachineStore
    {
        public Dictionary<Type, IMachine> Machines;
        public IFactoryMachine<TPart> GetMachine<TPart>()
        {
            //Move the problem to run-time;
            return Machines
                .Where(x => x.Value.Type == typeof (TPart))
                .Select(x=>x.Value)
                .OfType <IFactoryMachine<TPart>>()
                .Single();
        }
    }
    class Program
    {
        static public void Main()
        {
            var locator = new MachineStore();
            locator.Machines.Add(typeof(EngineMachine), new EngineMachine());
            locator.Machines.Add(typeof(SuperEngineMachine), new SuperEngineMachine ());
            var machine = locator.GetMachine<Engine>();
        }
    }
