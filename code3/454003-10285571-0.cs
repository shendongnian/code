    // This is the thing factory - it will create the thing if it has not already 
    // been created with the given ID - if it is already created it will return 
    // that instance
    public interface IThingFactory
    {
        Thing Get(int id);
    }
    // This is the thing - it has an ID and a method that you
    // can call that keeps track of how many times it has been
    // called (so you can be sure it is the same instance)
    public class Thing
    {
        private int _count;
        public Thing(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public int HowManyCalls()
        {
            return Interlocked.Increment(ref _count);
        }
    }
    // This is a typed factory selector to manage selecting the component from
    // the container by using the name ("Thing" followed by the ID)
    public class GetThingComponentSelector : ITypedFactoryComponentSelector
    {
        public TypedFactoryComponent SelectComponent(MethodInfo method, 
                                                     Type type, 
                                                     object[] arguments)
        {
            return new TypedFactoryComponent("Thing" + arguments[0],
                                             typeof(Thing),
                                             new Arguments(arguments));
        }
    }
    // .... In the installer ....
    // Register each thing with a different name that matches the ID
    // and register a custom component selector and the thing factory
    container
        .AddFacility<TypedFactoryFacility>()
        .Register(
            Component
                .For<Thing>()
                .Named("Thing1"),
            Component
                .For<Thing>()
                .Named("Thing2"),
            Component
                .For<GetThingComponentSelector>(),
            Component
                .For<IThingFactory>()
                .AsFactory(c => c.SelectedWith<GetThingComponentSelector>()));
    // ... Some demo code (you do not need to resolve the factory directly)
    // Now resolve the same thing twice and then a different thing and make sure
    // Windsor has handled the lifestyle
    var thing = container.Resolve<IThingFactory>().Get(1);
    Console.WriteLine("ID should be 1 and is " + thing.Id 
        + ". Calls should be 1 and is " + thing.HowManyCalls());
    thing = container.Resolve<IThingFactory>().Get(1);
    Console.WriteLine("ID should be 1 and is " + thing.Id 
        + ". Calls should be 2 and is " + thing.HowManyCalls());
    thing = container.Resolve<IThingFactory>().Get(2);
    Console.WriteLine("ID should be 2 and is " + thing.Id 
        + ". Calls should be 1 and is " + thing.HowManyCalls());
