    void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	var ResourceManager = new ResourceManager(typeof(Resources));
    	var ContextItem = (ToolStripMenuItem) sender;
    	var ContextMenu = (ContextMenuStrip) ContextItem.Owner;
    	var ToolStrip = (ToolStrip) ContextMenu.SourceControl;
    	var Checked = ContextItem.Checked;
    
    	ToolStrip.ImageScalingSize = Checked ? new Size(32, 32) : new Size(16, 16);
    
    	foreach(ToolStripButton Button in ToolStrip.Items)
    	{
    		var CurrentResource = Button.Tag.ToString();
    		var NewResource = CurrentResource.Substring(0, CurrentResource.Length - 2) + (Checked ? "32" : "16");
    		Button.Image = (Image) ResourceManager.GetObject(NewResource);
    		Button.Tag = NewResource;
    	}
    }
