    bool isSubscriptionEnabled = false;
        private void zedGraphControl1_ContextMenuBuilder(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            // Remove default options
            menuStrip.Items.RemoveByKey("unzoom");
            menuStrip.Items.RemoveByKey("undo_all");
            // custom context menu items
            ToolStripMenuItem unZoom_toolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem unZoomAll_toolStripMenuItem = new ToolStripMenuItem();
            // 1.Un Zoom
            unZoom_toolStripMenuItem.Name = "unZoom";
            unZoom_toolStripMenuItem.Tag = "unzoom";
            unZoom_toolStripMenuItem.Text = "Un Zoom*";
            // 2.Undo All Zoom/Pan
            unZoomAll_toolStripMenuItem.Name = "undoZoomAll";
            unZoomAll_toolStripMenuItem.Tag = "undozoomall";
            unZoomAll_toolStripMenuItem.Text = "Undo All Zoom/Pan*";
            // Add the above 2 menu strip items
            menuStrip.Items.Insert(4, unZoom_toolStripMenuItem);
            menuStrip.Items.Insert(5, unZoomAll_toolStripMenuItem);
            if (!isSubscriptionEnabled)
            {
                // The following event handler help us to notify user click event on context menu
                menuStrip.ItemClicked += new ToolStripItemClickedEventHandler(menuStrip_ItemClicked);
                isSubscriptionEnabled = true;
            }
        }
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.ToString() == "Un Zoom*")
            {
                // Add your custom task
                MessageBox.Show("Un Zoom");
                
            }
            else if (e.ClickedItem.ToString() == "Undo All Zoom/Pan*")
            {
                // Add your custom task
            }            
        }
