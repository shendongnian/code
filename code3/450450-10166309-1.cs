    public class TreeViewEx : TreeView
    {
    
        protected override bool IsItemItsOwnContainerOverride(object item) 
        {
            return (item is TreeViewItemEx);
        }
        
        protected override DependencyObject GetContainerForItemOverride() 
        {
            return new TreeViewItemEx(this);
        }
    
    	internal bool PreviewExpandTreeViewItem(TreeViewItemEx item)
    	{
    		// return true to allow expansion, false to cancel
    		return true;
    	}
    	
    }
    
    public class TreeViewItemEx : TreeViewItem
    {
        private readonly TreeViewEx Owner;
        
        static TreeViewItemEx()
        {
    		DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeViewItemEx), 
    			new FrameworkPropertyMetadata(typeof(TreeViewItemEx)));
        }
        
        public TreeViewItemEx(TreeViewEx owner)
        {
    		Owner = owner;
    	}
    	
    	private void OnPreviewExpansionMouseDown(object sender, MouseButtonEventArgs e)
    	{
    		// we do not care if it already expanded
    		if (IsExpanded)
    			return;
    			
    		e.Cancel = !Owner.PreviewExpandTreeViewItem(this);
    	}
    	
    }
