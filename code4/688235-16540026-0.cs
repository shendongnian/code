    //create menu items with cunstructor that takes 2 arguemtns (string, and event handler)
    
    MenuItem[] menuItems = new MenuItem[] { new MenuItem("Cut", new System.EventHandler(this.CutMenuItemClick)), 
                                            new MenuItem("Copy", new System.EventHandler(this.CopyMenuItemClick)),
                                            new MenuItem("Paste", new System.EventHandler(this.PasteMenuItemClick)) };
                                        
