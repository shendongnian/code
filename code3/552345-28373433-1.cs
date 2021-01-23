    public class Node
        {
            public int Id;
            public string text;
            public bool IsParent;
            public int parentId;
            public string url;
            public bool IsSelected;
            public bool IsExpanded = false;
        }
        
        public partial class SiteMaster : System.Web.UI.MasterPage
        {
            List<Node> lstNodes = new List<Node>();
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                  bindTree();
                }
            }
    
            TreeNode searchResult;
            public void SelectNodesRecursive(string searchValue, TreeView Tv)
            {
                foreach (TreeNode tn in Tv.Nodes)
                {
                    if (tn.Value == searchValue)
                    {
                        searchResult = tn;
                        break;
                    }
    
                    if (tn.ChildNodes.Count > 0)
                    {
                        foreach (TreeNode cTn in tn.ChildNodes)
                        {
                            int a = SelectChildrenRecursive(cTn, searchValue);
                            if (a == 1)
                            {
                                searchResult = cTn;
                            }
                        }
                    }
                }
            }
    
    
            private int SelectChildrenRecursive(TreeNode tn, string searchValue)
            {
                if (tn.Value == searchValue)
                {
                    searchResult = tn;
                    return 1;
                }
    
                if (tn.ChildNodes.Count > 0)
                {
                    foreach (TreeNode tnC in tn.ChildNodes)
                    {
                        int a = SelectChildrenRecursive(tnC, searchValue);
                        if (a == 1)
                        {
                            searchResult = tnC;
                            return 1;
                        }
    
                    }
    
                }
                searchResult = null;
                return 0;
            } 
             
    
            private void bindTree()
            {
                TreeNode parent = null, child = null;
    
                if (Session["TreeNodes"] == null)
                {
                    lstNodes = getTreeMenu();
                    Session["TreeNodes"] = lstNodes;
                }
                else
                {
                    lstNodes = (List<Node>)Session["TreeNodes"];
                }
    
                foreach (Node node in lstNodes)
                {
                    if (node.IsParent && node.parentId == 0)
                    {
                        parent = new TreeNode { Text = node.text, Value = node.Id.ToString()};
                        TreeView1.Nodes.Add(parent);
                        parent.Selected = node.IsSelected;
                        parent.Expanded = node.IsExpanded;
                    }
                    else
                    {
                        if (node.IsParent)
                        {
                            SelectNodesRecursive(node.parentId.ToString(), TreeView1);
                            parent = searchResult;
                            child = new TreeNode { Text = node.text, Value = node.Id.ToString()};
                            parent.ChildNodes.Add(child);
                            child.Selected = node.IsSelected;
                            child.Expanded = node.IsExpanded;
                        }
                        else
                        {
                            child = new TreeNode { Text = node.text, Value = node.Id.ToString()};
                            SelectNodesRecursive(node.parentId.ToString(), TreeView1);
                            parent = searchResult;
    
                            if (parent != null)
                            {
                                parent.ChildNodes.Add(child);
                                child.Selected = node.IsSelected;
                                child.Expanded = node.IsExpanded;
                            }
                            else
                            {
                                child.Selected = node.IsSelected;
                                child.Expanded = node.IsExpanded;
                            }
                        }
                    }
                } 
            }
    
            private List<Node> getTreeMenu()
            {
                List<Node> treeSource = new List<Node>();
            treeSource.Add(new Node { Id = 1, IsParent = true, parentId = 0, text = "parent1", url = "home.aspx?id=1", IsExpanded = true });
            treeSource.Add(new Node { Id = 2, IsParent = false, parentId = 1, text = "Child 1", url = "page1.aspx" });
            treeSource.Add(new Node { Id = 3, IsParent = false, parentId = 1, text = "Child 2", url = "Page2.aspx" });
            treeSource.Add(new Node { Id = 4, IsParent = false, parentId = 1, text = "Child 3", url = "Page3.aspx" });
            treeSource.Add(new Node { Id = 5, IsParent = true, parentId = 0, text = "parent 2", url = "home.aspx?id=5", IsExpanded = false });
            treeSource.Add(new Node { Id = 6, IsParent = false, parentId = 5, text = "child 1", url = "page1.aspx" });
            treeSource.Add(new Node { Id = 7, IsParent = true, parentId = 5, text = "parent 3", url = "home.aspx?id=7", IsExpanded=false });
            treeSource.Add(new Node { Id = 14, IsParent = false, parentId = 7, text = "child 1", url = "page1.aspx" });
            treeSource.Add(new Node { Id = 15, IsParent = false, parentId = 7, text = "child 2", url = "page2.aspx" });
            treeSource.Add(new Node { Id = 8, IsParent = false, parentId = 5, text = "child 3", url = "Page3.aspx" });
            treeSource.Add(new Node { Id = 9, IsParent = true, parentId = 0, text = "parent 4", url = "home.aspx?id=9", IsExpanded = false });
            treeSource.Add(new Node { Id = 10, IsParent = false, parentId = 9, text = "child 1", url = "page1.aspx" });
            treeSource.Add(new Node { Id = 11, IsParent = false, parentId = 9, text = "child 2", url = "Page2.aspx" });
            treeSource.Add(new Node { Id = 12, IsParent = false, parentId = 9, text = "child 3", url = "Page3.aspx" });
            treeSource.Add(new Node { Id = 13, IsParent = true, parentId = 0, text = "parent 5", url = "About.aspx" });
            return treeSource;
            }
    
            protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
            {
                string selVal = TreeView1.SelectedValue;
                lstNodes = (List<Node>)Session["TreeNodes"];
                if (lstNodes != null)
                {
                    Node nd = lstNodes.Find(n => n.Id.ToString() == selVal);
    
                    foreach (Node item in lstNodes.FindAll(n => n.Id.ToString() != selVal))
                    {
                        item.IsSelected = false;
                    }
    
                    nd.IsSelected = true;
                    Session["TreeNodes"] = lstNodes;
                    if (nd.url != "")
                        Response.Redirect(nd.url);
                }
            }
    
            protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
            {   
                lstNodes = (List<Node>)Session["TreeNodes"];
                if (lstNodes != null)
                {
                    Node nd = lstNodes.Find(n => n.Id.ToString() == e.Node.Value);
                    nd.IsExpanded = true;
                    Session["TreeNodes"] = lstNodes;
                } 
            }
    
            protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
            {
                lstNodes = (List<Node>)Session["TreeNodes"];
    
                if (lstNodes != null)
                {
                    Node nd = lstNodes.Find(n => n.Id.ToString() == e.Node.Value);
                    nd.IsExpanded = false;
                    Session["TreeNodes"] = lstNodes;
                }
            }
        }
