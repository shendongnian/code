    public class SomeClass
    {
        public IDictionary<string, Action> ActionRegistry { get; set; }
        public void SomeMethod()
        {
            // Registering an action:
            ActionRegistry.Add("SomeAction", () => { });
            // Invoking:
            ActionRegistry["SomeAction"]();
        }
    }
