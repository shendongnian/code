    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if(Session["lastNode"] != null)
        {
           TreeNode lastNode = Session["lastNode"] as TreeNode;
                    
           TreeNode tn = TreeView1.FindNode(Server.HtmlEncode(lastNode.ValuePath));
           tn.Text = tn.Text.Replace(@"color=""Red""", @"color=""Blue""");
    
         }
    
        Session["lastNode"] = TreeView1.SelectedNode;
    }
