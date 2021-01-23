    internal class CommandController
    {
        private ICommandService commandService;
    
        public void RegisterCommands()
        {
            this.commandService.Register("ExampleCommand", this.ExampleCommandHandler);
        }
    
        private ExampleCommandHandler exampleCommandHandler;
    }
    
    internal class ExampleCommandHandler : ICommandHandler
    {
        void Execute()
        {
        }
    }
