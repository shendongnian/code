    public class InitialDataForBrowser
    {
        public ParentNode Parent { get; set; }
        public string MyName { get; set; }
        public InitialDataForBrowser()
        {
            Parent = new ParentNode();
            MyName = "InitialDataForBrowser";
        }
    }
    public class ParentNode
    {
        public ChildNode Child { get; set; }
        public string MyName { get; set; }
        public ParentNode()
        {
            Child = new ChildNode();
            MyName = "Parent";
        }
    }
    public class ChildNode
    {
        public string MyName { get; set; }
        public ChildNode()
        {
            MyName = "Child";
        }
    }
