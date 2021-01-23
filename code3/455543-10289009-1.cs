    public class ErrorHandlerElement : BehaviorExtensionElement
        {
        public override Type BehaviorType
            {
            get { return typeof (ErrorHandlerBehavior); }
            }
        protected override object CreateBehavior ()
            {
            return new ErrorHandlerBehavior ();
            }
        }
    }
