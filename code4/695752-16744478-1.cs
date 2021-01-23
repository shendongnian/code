    public TestImplClass {
        public ICommand CreateNode { get; private set; }
        public ICommand CreateNodeWithProperties { get; private set; }
        public TestImplClass(ICommand createNode, ICommand createNodeWithProperties) {
            this.CreateNode = createNode;
            this.CreateNodeWithProperties = createNodeWithProperties;
        }
    }
