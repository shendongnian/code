    // People often exclude the applicable "using" statements--so samples don't work!
    using System.Web.UI.WebControls; 
    
    // Create the MAIN menu item
    MenuItem mnuMenuItem = new MenuItem();         
    
    // Create the SUB menu item
    MenuItem mnuSubMenuItem = new MenuItem();      
    
    // Create the SUB menu item, "under" the MAIN menu item!
    mnuMenuItem.ChildItems.Add(mnuSubMenuItem);  
