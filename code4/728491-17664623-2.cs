    public class SomeClass
    {
        public IDictionary<string, Action> ActionRegistry { get; set; }
        public void SomeMethod()
        {
            // Registering an action that doesn't use reflection:
            ActionRegistry.Add("SomeAction", () => { Console.WriteLine("Hello");});
            // Registering an action that uses reflection
            object objectInstance; = ...
            Type type; = ...
            string methodName; = ...
            object[] arguments; = 
            ActionRegistry.Add("SomeAction2", () =>
            {
                type.GetMethod(methodName).Invoke(objectInstance, arguments);
            });
            // Invoking:
            ActionRegistry["SomeAction2"]();
        }
    }
