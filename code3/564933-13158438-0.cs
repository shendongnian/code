            ContextMenu contextmenu = new ContextMenu();
            MenuItem CmbFontColoreMenu = new MenuItem();
            ComboBox CmbColorMenu = new ComboBox();
            CmbColorMenu.ItemsSource = FontColors;// FontColors is list<objects>
            CmbColorMenu.DisplayMemberPath = "Text";
            CmbFontColoreMenu.ContainerFromElement(CmbColorMenu);
            contextmenu.Items.Add(CmbFamilyMenu);
