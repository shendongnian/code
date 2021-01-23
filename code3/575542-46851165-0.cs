    private MenuItem[] standardMenuItems;
    private MenuItem[] selectedMenuItems;
    
    public SomePanel() {
    	InitializeComponent();
    
    	// These are list of menu items (name / callback) that will be
    	// chosen depending on some context
    	standardMenuItems = new MenuItem[] { new MenuItem("New", OnNew) };
    	selectedMenuItems = new MenuItem[] { new MenuItem("Delete", OnDelete), new MenuItem("Edit", OnEdit) };
    
    	ContextMenu contextMenu = new ContextMenu();
    
    	// begin with "standard items"
    	contextMenu.MenuItems.AddRange(standardMenuItems);
    	listview.ContextMenu = contextMenu;
    
    	// add the popup handler
    	contextMenu.Popup += OnMenuPopup;
    }
    
    // Called right before the menu comes up
    private void OnMenuPopup(object sender, EventArgs e) {
    	ContextMenu menu = sender as ContextMenu;
    	if (menu == null)
    		return;
    	
    	// If an item was selected, display Delete and Edit options
    	if (listview.SelectedItems.Count > 0) {
    		menu.MenuItems.Clear();
    		menu.MenuItems.AddRange(selectedMenuItems);
    	}
    
    	// Else display only the New option
    	else {
    		menu.MenuItems.Clear();
    		menu.MenuItems.AddRange(standardMenuItems);
    	}
    }
