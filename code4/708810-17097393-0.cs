        [Serializable]
        public class CustomException : Exception
        {
            public CustomException() { }
            public CustomException(string message) : base(message) { }
            public CustomException(string message, Exception inner) : base(message, inner) { }
            protected CustomException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
        [Serializable]
        public class AlreadySentException : CustomException
        {
            public AlreadySentException() { }
            public AlreadySentException(string message) : base(message) { }
            public AlreadySentException(string message, Exception inner) : base(message, inner) { }
            protected AlreadySentException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
        [Serializable]
        public class InvalidMessageException : CustomException
        {
            public InvalidMessageException() { }
            public InvalidMessageException(string message) : base(message) { }
            public InvalidMessageException(string message, Exception inner) : base(message, inner) { }
            protected InvalidMessageException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }
