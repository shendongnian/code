    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var pages = GetPagesByParent(Page);
            if (pages.Count() > 0)
            {
                var roots = pages.Where(p => p.Parent == null);
                foreach (var root in roots)
                {
                    //add the root nodes to the tree
                    var rootNode = new TreeNode(root.Title);
                    tree.Nodes.Add(rootNode);
    
                    //kick off the recursive population
                    PopulateChildNodes(pages, root, rootNode);
                }
            }
        }
    }
    protected void PopulateChildNodes(IEnumerable<Page> pages, Page parent, TreeNode parentNode)
    {
        var childPages = pages.Where(p => p.Parent == parent);
        foreach (var page in pages)
        {
            var pageNode = new TreeNode(page.Title);
            parentNode.Nodes.Add(pageNode);
            //populate the children of the pageNode
            PopulateChildNodes(pages, page, pageNode);
        }
    }
