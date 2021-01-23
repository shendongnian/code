      `private void StatusButtonContextMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            var parent = (item.Owner as ContextMenuStrip);
            for (int i = 0; i < parent.Items.Count; i++)
            {
                if (item == parent.Items[i])
                {
                    index = i;
                    break;
                }
            }
        }`
