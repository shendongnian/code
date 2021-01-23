    class TreeNode
    {
      public string Data { get; private set; }
      public TreeNode FirstChild { get; private set; }
      public TreeNode NextSibling { get; private set; }
      public TreeNode (string data, TreeNode firstChild, TreeNode nextSibling)
      {
        this.Data = data;
        this.FirstChild = firstChild;
        this.NextSibling = nextSibling;
      }
    }
