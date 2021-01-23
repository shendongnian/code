    private void AddTabPage()
    {
        // Add new tab page and dock fill.
        TabPage tab = new TabPage(Path.GetFileName(fullPath));
        TextEditorControl editor = new TextEditorControl();
        editor.Dock = System.Windows.Forms.DockStyle.Fill;
        
        // Add the new tab to the tab control.
        tab.Controls.Add(editor);
        fileTabs.Controls.Add(tab);
        fileTabs.SelectedTab = tab;
    }
    
