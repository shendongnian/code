            ContextMenu contextmenu = new ContextMenu();
            ComboBox CmbColorMenu = new ComboBox();
            CmbColorMenu.ItemsSource = FontColors;// FontColors is list<objects>
            CmbColorMenu.DisplayMemberPath = "Text";
            contextmenu.Items.Add(CmbColorMenu);
