        private void DeviceActionsContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == addDeviceToolStripMenuItem)
            {
                (contextMenuStrip1.SourceControl as Label).BackColor = Color.Green;
            }
        }
