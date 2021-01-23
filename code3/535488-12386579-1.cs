    internal sealed class GenericCallbackClass<T> : GenericCallbackClassBase
    where T : ICallbackMessageBase
    {
        public GenericCallbackClass(T message)
            : base(message) { }
        public new T Message
        {
            get { return (T)base.Message; }
        }
    }
