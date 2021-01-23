    public partial class Form1 : Form
    	{
    		private class ItemInfo
    		{
    			public int ID;
    			public int ParentID;
    			public string Name;
    		}
    
    		public Form1()
    		{
    			InitializeComponent();
    			FillTreeView();
    		}
    
    		private void FillTreeView()
    		{
    			var items = new List<ItemInfo>()
    			{
    				new ItemInfo(){ID = 1, ParentID = 4, Name = "A"},
    				new ItemInfo(){ID = 2, ParentID = 1, Name = "A1"},
    				new ItemInfo(){ID = 3, ParentID = 0, Name = "B"},
    				new ItemInfo(){ID = 4, ParentID = 0, Name = "C"},
    				new ItemInfo(){ID = 5, ParentID = 1, Name = "A2"},
    				new ItemInfo(){ID = 6, ParentID = 3, Name = "B1"},
    			};
    
    			FillNode(items, null);
    		}
    
    		private void FillNode(List<ItemInfo> items, TreeNode node)
    		{
    			var parentID = node != null
    				? (int)node.Tag
    				: 0;
    
    			var nodesCollection = node != null
    				? node.Nodes
    				: treeView1.Nodes;
    
    			foreach (var item in items.Where(i => i.ParentID == parentID))
    			{
    				var newNode = nodesCollection.Add(item.Name, item.Name);
    				newNode.Tag = item.ID;
    
    				FillNode(items, newNode);
    			}
    		}
    	}
