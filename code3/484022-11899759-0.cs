    public class AspNetSafeBackgroundCommandHandlerDecorator<T>
        : ICommandHandler<T>, IRegisteredObject
    {
        private readonly ICommandHandler<T> decorated;
        
        private readonly object locker = new object();
        
        public AspNetSafeBackgroundCommandHandlerDecorator(
            ICommandHandler<T> decorated)
        {
            this.decorated = decorated;
        }
        
        public void Handle(T command)
        {
            HostingEnvironment.RegisterObject(this);
            
            try
            {
                lock (this.locker)
                {
                    this.decorated.Handle(command);
                }
            }
            finally
            {
                HostingEnvironment.UnregisterObject(this);
            }            
        }
        void IRegisteredObject.Stop(bool immediate)
        {
            // Ensure waiting till Handler finished.
            lock (this.locker)
            {
                _shuttingDown = true;
            }
        }
    }
