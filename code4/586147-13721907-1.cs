    var menustrip1 = new System.Windows.Forms.MenuStrip();
    var item = new System.Windows.Forms.ToolStripMenuItem()
    {
        Name = "Test",
        Text = "Test" 
    };
    var item2 = new System.Windows.Forms.ToolStripMenuItem()
    {
        Name = "Test",
        Text = "Test"
    };
    item.DropDownItems.Add(item2);
    menustrip1.Items.Add(item);
