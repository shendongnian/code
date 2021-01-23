    public class MenuItemWrap
    	{
    		MenuItem _mnuItem;
    		ListPresentationViewModel _parent;		
    
    		public MenuItemWrap (MenuItem item, ListPresentationViewModel parent)
    		{
    			_mnuItem = item;
    			_parent = parent;
    		}
    
    
    		public IMvxCommand OrderClick {
    			get {
    				return new MvxCommand (() => _parent.btnClick (_mnuItem));
    			}
    		}
    
    		public MenuItem Item{ get { return _mnuItem; } }    
    	}
