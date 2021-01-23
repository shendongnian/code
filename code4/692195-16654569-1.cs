    private void TreeForm_Load(object sender, EventArgs e)
    {
         treeList1.DataSource = Service.GetServices();
         treeList1.NodesIterator.DoLocalOperation(setNodeVisibility, treeList1.Nodes);
    }
    
    private void setNodeVisibility(DevExpress.XtraTreeList.Nodes.TreeListNode node)
    {
         var service = treeList1.GetDataRecordByNode(node) as Service;
         if (service == null)
             return;
    
         node.Visible = service.Visible;
    }
