    private void zedGraphControl1_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            // The following event handler help us to notify user click event on context menu
            menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStrip_ItemClicked);
        }
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString() == "Un-Zoom")
            {
                // Add your custom task
            }
            if (e.ClickedItem.ToString() == "Undo All Zoom/Pan")
            {
                // Add your custom task
            }
        }
