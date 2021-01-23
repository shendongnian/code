    [Serializable]
    public class MyException : Exception
    {
        public MyCustomObject CustomObject { get; private set; }
        public MyException(MyCustomObject customObject)
        {
            CustomObject = customObject;
        }
        public MyException(string message, MyCustomObject customObject)
            : base(message)
        {
            CustomObject = customObject;
        }
        public MyException(string message, Exception inner, MyCustomObject customObject)
            : base(message, inner)
        {
            CustomObject = customObject;
        }
        protected MyException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            // TODO: Implement serializable stuff.
        }
        #region Overrides of Exception
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO: Implement serializable stuff.
            base.GetObjectData(info, context);
        }
        #endregion
    }
