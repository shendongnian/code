    public interface IExceptionEmailer {
        void HandleGenericException( Exception e );
        void HandleYourExceptionTypeA ( ExceptionTypeA e );
        // ... continue with your specific exceptions
    }
    public class YourClassThatCatchesExceptions( ){ 
        private IExceptionEmailer emailer;
        public void TheMethodThatCatches ( ) {
            try {
                // actions
            } catch ( ExceptionTypeA e ) {
                this.emailer.HandleYourExceptionTypeA( e );
            } catch ( Exception e ) {
                this.emailer.HandleGenericException( e );
            }
        }
        public YourClassThatCatchesExceptions( IExceptionEmailer emailer ) {
            this.emailer = emailer;
        }
    }
