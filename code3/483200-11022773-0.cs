    public class ElmahErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return false;
        }
    
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error == null)
            {
                return;
            }
            ErrorSignal.FromCurrentContext().Raise(error);
        }
    }
