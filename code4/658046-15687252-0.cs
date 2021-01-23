    class MessageBase
    {
        protected void DoDispatch<T>(T m)
        {
            // ...
        }
    }
    class Message<T> : MessageBase where T : class
    {
        public void Dispatch()
        {
            DoDispatch<T>(this as T);
        }
    }
    class MyMessage : Message<MyMessage>
    {
    }
