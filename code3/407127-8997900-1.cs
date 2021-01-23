    private void MenuItemClickHandler(object sender, EventArgs e)
    {
        ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
        var t = Type.GetType("MyNamespace." + clickedItem.Name));
        var control = (UserControl)Activator.CreateInstance(t);
        this.Controls.Add(control);    
    }
    
