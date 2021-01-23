    public class ExceptionSerializer {
        private readonly Exception _Ex;
        public serializableException(Exception e) {
          _Ex = e;
        }
     
        [Flag_you_want_here]
        public SerializableMessage { get{ _Ex.Message;} }
        
    }
