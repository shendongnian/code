    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var pages = GetPagesByParent(Page);
            if (pages.Count() > 0)
            {
                var root = pages.FirstOrDefault(p => p.Parent == null);
                if (root != null)
                {
                    var rootNode = new TreeNode(root.Title);
                    tree.Nodes.Add(rootNode);
    
                    var childPages = pages.Where(p => p.Parent == root);
                    foreach (var page in pages)
                    {
                        var childNode = new TreeNode(page.Title);
                        rootNode.Nodes.Add(childNode);
    
                        PopulateChildNodes(pages, childNode);
                    }
                }
            }
        }
    }
    protected void PopulateChildNodes(IEnumerable<Page> pages, TreeNode parentNode)
    {
        var childPages = pages.Where(p => p.Parent == parent);
        foreach (var page in pages)
        {
            var childNode = new TreeNode(page.Title);
            parentNode.Nodes.Add(childNode);
            //populate the children of the childNode
            PopulateChildNodes(pages, childNode);
        }
    }
