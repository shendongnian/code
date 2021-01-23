    // MainWindowController...
            public override void AwakeFromNib()
    		{
    			rootNode = new Node(new NSString("Root Node"));
    
    			for(int i = 1; i <=5; i++)
    			{
    				rootNode.Children.Add(new Node(new NSString("Child Node")));
    			}
    
    			sourceList.Delegate = new SourceListDelegate(this);
    			sourceList.DataSource = new SourceListDataSource(this);
    
    			base.AwakeFromNib();
    		}
    
    		private class SourceListDataSource : NSOutlineViewDataSource
    		{
    			private MainWindowController controller;
    
    			public SourceListDataSource(MainWindowController controller)
    			{
    				this.controller = controller;
    			}
    
    			public override int GetChildrenCount(NSOutlineView outlineView, NSObject item)
    			{
    				if(item != null)
    				{
    					return (int)((Node)item).Count;
    				}
    
    				return (int)controller.rootNode.Count;
    			}
    
    			public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
    			{
    				if(item == null)
    				{
    					return false;
    				}
    
    				return !((Node)item).Leaf;
    			}
    
    			public override NSObject GetChild(NSOutlineView outlineView, int childIndex, NSObject item)
    			{
    				if(item == null)
    				{
    					return (Node)Runtime.GetNSObject(controller.rootNode.Children.ValueAt((uint)childIndex));
    				}
    
    				Node theItem = (Node)item;
    				return (Node)Runtime.GetNSObject(theItem.Children.ValueAt((uint)childIndex));
    			}
    
    			public override NSObject GetObjectValue(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
    			{
    				if(item != null)
    				{
    					return ((Node)item).Text;
    				}
    
    				return new NSString("");
    			}
    		}
    
    		private class SourceListDelegate : NSOutlineViewDelegate
    		{
    			private MainWindowController controller;
    
    			public SourceListDelegate(MainWindowController controller)
    			{
    				this.controller = controller;
    			}
    
    			public override bool IsGroupItem(NSOutlineView outlineView, NSObject item)
    			{
    				return (Node)item == controller.rootNode;
    			}
    
    			public override bool ShouldEditTableColumn(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
    			{
    				return true;
    			}
    
    			public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
    			{
    				if(IsGroupItem(outlineView, item))
    				{
    					return outlineView.MakeView("HeaderCell", this);
    				}
    
    				var view = outlineView.MakeView("DataCell", this);
    				var node = (Node)item;
    
    				((NSTextField)view.Subviews[1]).StringValue = node.Text;
    				((NSTextField)view.Subviews[1]).Changed += HandleChanged;
    
    				return view;
    			}
    
    			void HandleChanged (object sender, EventArgs e)
    			{
    				Console.WriteLine("changed");
    			}
    		}
    
    		private class Node : NSObject
    		{
    			private NSMutableArray children = new NSMutableArray();
    
    			public NSMutableArray Children
    			{
    				get
    				{
    					return children;
    				}
    			}
    
    			public uint Count
    			{
    				get
    				{
    					return Children.Count;
    				}
    			}
    
    			public bool Leaf
    			{
    				get
    				{
    					return this.Count == 0;
    				}
    			}
    
    			public NSString Text { get; set; }
    
    			public Node(NSString text)
    			{
    				this.Text = text;
    			}
    		}
