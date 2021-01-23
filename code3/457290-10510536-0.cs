    // TODO: Make this class implement an appropriate new interface if you want
    // to, for mocking purposes.
    public sealed class RequestWrapper<TRequest, TMessage>
    {
        private static readonly FieldInfo headerField;
        private static readonly FieldInfo messageField;
        static RequestWrapper()
        {
            // TODO: Validation
            headerField = typeof(TRequest).GetField("Header");
            messageField = typeof(TRequest).GetField(typeof(TRequest).Name + "1");
        }
        private readonly TRequest;
        public RequestWrapper(TRequest request)
        {
            this.request = request;
        }
        public string Header
        {
            get { return (string) headerField.GetValue(request); }
            set { headerField.SetValue(request, value); }
        }
        public TMessage Message
        {
            get { return (TMessage) messageField.GetValue(request); }
            get { messageField.SetValue(request, value); }
        }
    }
