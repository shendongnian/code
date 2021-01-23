    // This class will be part of the Composition Root of
    // the Windows Forms applicatoin
    private class LifetimeScopeCommandHandlerProxy<T>
        : ICommandHandler<T>
    {
        // Since this type is part of the composition root,
        // we are allowed to inject the container into it.
        private Container container;
        private Func<ICommandHandler<T>> instanceCreator;
        public LifetimeScopeCommandHandlerProxy(
             Container container,
             Func<ICommandHandler<T>> creator)
        {
            this.instanceCreator = creator;
            this.container = container;
        }
        public void Handle(T command)
        {
            using (this.container.BeginLifetimeScope())
            {
                var handler = this.instanceCreator();
                    
                handler.Handle(command);        
            }
        }
    }
