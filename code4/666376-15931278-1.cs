    class SomeCommand : ICommand
    {
        // ...
        public void Dispatch(IoC ioc)
        {
            var handler = ioc.Get<IHandle<SomeCommand>>();
            handler.Handle(this);
        }
    }
