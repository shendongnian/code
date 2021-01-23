    private TreeView treeView1;
    private void TreeView_DataBind() {
      treeView1.Nodes.Clear();
      List<DocumentData> lstData = GetSPDocuments();
      gvDocuments.DataSource = lstData;
      gvDocuments.DataBind();
      DataTable dt = ConvertToDataTable(lstData);
      TreeNode node1 = new TreeNode("Root");
      treeView1.Nodes.Add(node1); // this is the step you missed
      foreach (DataRow r in dt.Rows)
      {
        int nodeLvl = int.Parse(r["ID"].ToString());
        string nodeParent = "Folders";
        string nodeName = r["Title"].ToString();
        TreeNode tNode = new TreeNode(nodeName);
        ht.Add(nodeLvl.ToString() + nodeName, tNode);
        if (tvDocs.Nodes.Count == 0)
          tvDocs.Nodes.Add(tNode);
        else
        {
          nodeLvl--;
          tvDocs.Nodes.Add(tNode);               
        }
      }
      node1.Expand();
    }
