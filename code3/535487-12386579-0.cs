    internal class GenericCallbackClassBase
    {
        public GenericCallbackClassBase(ICallbackMessageBase message)
        {
            Message = message;
        }
        public ICallbackMessageBase Message { get; private set; }
    }
