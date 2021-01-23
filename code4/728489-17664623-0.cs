    public class SomeClass
    {
        public IDictionary<string, Action> ActionRegistry { get; set; }
        public SomeClass()
        {
            ActionRegistry.Add("SomeAction", () => {});
        }
    }
