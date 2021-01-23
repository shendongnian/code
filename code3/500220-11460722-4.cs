    public void BuildMenumStructure(){
        //Instantiate a File menu
        MenuItem root = new MenuItem("File");
        root.Level = 0;
        //Add some menu items
        root.MenuItems.Add(new MenuItem("New"){Level = 1});
        root.MenuItems.Add(new MenuItem("Edit"){Level = 1});
        //Build a save menu and add it in
        MenuItem saveMenu = new MenuItem("Save");
        saveMenu.MenuItems.Add(new MenuItem("Save As"){Level = 2});
        saveMenu.MenuItems.Add(new MenuItem("Save"){Level = 2});
        root.MenuItems.Add(saveMenu);
    }
