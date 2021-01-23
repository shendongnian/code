    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    public class Form1
    {
    
    	private void Form1_Load(System.Object sender, System.EventArgs e)
    	{
    		TreeList1.Columns.Clear();
    		TreeListColumn newColumn = TreeList1.Columns.Add();
    		newColumn.Caption = "Tree Column";
    		newColumn.Visible = true;
    
    		TreeList1.Nodes.Clear();
    		TreeListNode rootNode = TreeList1.Nodes.Add({ "Root Node" });
    		TreeListNode child1 = rootNode.Nodes.Add({ "Child 1" });
    		child1.Nodes.Add({ "GrandChild 1.1" });
    		child1.Nodes.Add({ "GrandChild 1.2" });
    
    		TreeListNode child2 = rootNode.Nodes.Add({ "Child 2" });
    		child2.Nodes.Add({ "GrandChild2.1" });
    		child2.Nodes.Add({ "GrandChild2.2" });
    		child2.Nodes.Add({ "GrandChild2.3" });
    
    		TreeList1.RefreshNode(rootNode);
    	}
    }
