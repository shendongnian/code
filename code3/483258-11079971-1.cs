    public class RegisterAreaMessage : IEventMessage
    {
        public string LinkText { get; private set; }
        public string AreaName { get; private set; }
        public string ControllerName { get; private set; }
        public string ActionName { get; private set; }
        //...
    }
