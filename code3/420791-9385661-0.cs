    public class OpenViewPayload
    {
        public string ViewName;
        public object Context;
        public Action callback;
    }
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class OpenViewEvent : CompositePresentationEvent<OpenViewPayload>
    {
    }
