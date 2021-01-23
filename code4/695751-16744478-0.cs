    interface ICommand {
        HttpMethod HttpMethod { get; }    
        string QueryUriSegment { get; }
        void Execute();
    }
    class abstract BaseCommand : ICommand {
        public abstract HttMethod { get; }
        public abstract string QueryUriSegment { get; }
    }
    class CreateNodeCommand : ICommand {
        public override HttpMethod HttpMethod { get { /* return HttpMethod for "create node" */ } }
        public override string QueryUriSegment { get { /* return QueryUriString for "create node" */ } }
        public void Execute() { /* Create node... */ }
    }
    class CreateNodeWithPropertiesCommand : ICommand {
        public override HttpMethod HttpMethod { get { /* return HttpMethod for "create node with properties" */} }
        public override string QueryUriSegment { get { /* return QueryUriString for "create node with properties" */ } }
        public void Execute() { /* Create node with properties ... */ }
    }
