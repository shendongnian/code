    public class EstatePartHandler : ContentHandler
    {
        private readonly IOrchardServices Services;
        public EstatePartHandler(IOrchardServices services, IAnotherDependency another)
        {
            Services = services;
            Another = another;
        }
    ...
    }
