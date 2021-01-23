        public TransactionalCommandHandlerDecorator<TCommand>
            : ICommandHandler<TCommand>
        {
            private ICommandHandler<TCommand> decoratedHandler;
            public TransactionalCommandHandlerDecorator(
                ICommandHandler<TCommand> decoratedHandler)
            {
                this.decoratedHandler = decoratedHandler;
            }
            public void Handle(TCommand command)
            {
                using (var scope = new TransactionScope())
                {
                    this.decoratedHandler.Handle(command);
                    scope.Complete();
                }
            }
        }
