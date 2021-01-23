    public string SelectedValue 
    { 
         get { return treeView1.SelectedNode.Text; }
    }    
    void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
         // this means that user clicked on tree view
         DialogResult = DialogResult.OK;
         Close();
    }
