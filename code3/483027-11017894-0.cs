        public interface IMsg
        {
            // let `MessageType` be a class
            MessageType Type { get; }
            byte[] Data { get; }
        }
