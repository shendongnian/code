        int tabCount = 5;
        tabControl.TabPages.Clear();
            
        List<ComboBox> comboboxes = new List<ComboBox>(tabCount);
        for (int i = 0; i < tabCount; i++)
        {
            TabPage tabPage = new TabPage();
            ComboBox comboBox = new ComboBox();
            comboboxes.Add(comboBox);
            tabPage.Controls.Add(comboBox);
            tabControl.TabPages.Add(tabPage);
        }
        // You can access the values using the 'comboboxes' list now.
