    public class SomethingSpecificException : Exception {
        public Control SomeProperty {get;private set;}
        public SomethingSpecificException(string message, Control control)
              : base(message)
        {
           SomeProperty = control;
        }
        ...
    }
