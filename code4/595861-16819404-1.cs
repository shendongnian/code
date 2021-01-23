     protected void TreeView1_TreeNodePopulate(Object sender, TreeNodeEventArgs e)
     {
         string id= e.Node.Value;
         //do your "select from yourTable where parentId =" + id;
         foreach (DataRow row in table.Rows)
         {
             TreeNode node = new TreeNode(row["title"], row["id"])
             node.PopulateOnDemand = true;    
             e.Node.ChildNodes.Add(node);
         }
    
     }
