    // Set  
    ContextMenuStrip menu = new ContextMenuStrip();
    menu.Items.Add(new ToolStripMenuItem("Item1", aNiceImage, someFunction));
    menu.Items.Add(new ToolStripMenuItem("Item2", alsoNiceImage, someOtherFunction));
    //Get
    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) 
    {
       contextMenuStrip1.Items[3].Select();
    }
