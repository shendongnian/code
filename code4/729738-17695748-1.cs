      using System;
      using System.Runtime.Serialization;
    
      [Serializable]
      public class CustomException : Exception
      {
        //
        // For guidelines regarding the creation of new exception types, see
        //    https://msdn.microsoft.com/en-us/library/ms229064(v=vs.100).aspx
        //
    
        public CustomException()
        {
        }
    
        public CustomException(string message) : base(message)
        {
        }
    
        public CustomException(string message, Exception inner) : base(message, inner)
        {
        }
    
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    
        public static CustomException FromJson(dynamic json)
        {
          string text = ""; // parse from json here
    
          return new CustomException(text);
        }
      }
