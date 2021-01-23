    class BaseMessage
    {
        protected virtual byte[] SerializeProperties()
        {
            var bytes = new List<byte>();
            bytes.AddRange(...); // serialize BaseMessage properties
            return bytes.ToArray();
        }
    }
    class BaseCommandMessage
    {
        protected override byte[] SerializeProperties()
        {
            var bytes = new List<byte>(base.SerializeProperties());
            bytes.AddRange(...); // serialize BaseCommandMessage properties
            return bytes.ToArray();
        }
    }
    class CommandMessage
    {
        protected override byte[] SerializeProperties()
        {
            // A call to this method will call BaseCommandMessage.SerializeProperties,
            //   and indirectly call BaseMessage.SerializeProperties
            var bytes = new List<byte>(base.SerializeProperties());
            bytes.AddRange(...); // serialize CommandMessage properties
            return bytes.ToArray();
        }
    }
