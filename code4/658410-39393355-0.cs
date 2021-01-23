    class MyClass
    {
        public int A;
        public string B;
    }
    ...
    TreeNode Node = TreeView.Nodes.Add("AAA");
    MyClass Data = new MyClass();
    Node.Tag = Data;
