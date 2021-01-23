    public class DoSomethingHandler
        : ICommandHandler<DoSomethingData>
    {
        public void Handle(DoSomethingData command)
        {
            // does the actual something
            DoSomethingInternal(command); 
        }
    }
