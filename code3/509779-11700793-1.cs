     protected void Page_Load(object sender, EventArgs e)
     {
     TreeNode pn = new TreeNode("Menu Item A");
         TreeNode cn1 = new TreeNode("<a href='http://www.google.com.pk/' >Sub Menu Link 1</a>");
        TreeNode cn2 = new TreeNode("<a href='http://www.google.com.pk/' >Sub Menu Link 2</a>");
        TreeNode cn3 = new TreeNode("<a href='http://www.google.com.pk/' >Sub Menu Link 3</a>");
        TreeView tv = new TreeView();
        tv.Nodes.Add(pn);
        tv.Nodes[0].ChildNodes.Add(cn1);
        tv.Nodes[0].ChildNodes.Add(cn2);
        tv.Nodes[0].ChildNodes.Add(cn3);        
        panel.Controls.Add(tv);
     }
