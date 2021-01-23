    public class WcfExceptionHandlerCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private ICommandHandler<T> wrapped;
    
        public ValidationCommandHandlerDecorator(ICommandHandler<T> wrapped)
        {
            this.wrapped = wrapped;
        }
    
        public void Handle(T command)
        {
            try
            {
                // does the actual something
                this.wrapped.Handle(command);
                _publicationChannel.StatusUpdate(new Info
                { 
                    Status = transitionResult.NewState 
                });
            }
            catch (FaultException<MyError> faultException)
            {
                if (faultException.Detail.ErrorType == MyErrorTypes.EngineIsOffline)
                {
                    TryFireEvent(MyServiceEvent.Error, faultException.Detail);
                }
                
                throw;
            }
        }
    }
