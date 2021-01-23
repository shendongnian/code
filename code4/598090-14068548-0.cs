     private void Form1_Load(object sender, EventArgs e)
            {
                toolStripStatusLabel1.Text = "Ready...";
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    TraverseMenuItemHint(item);
                }
            }
    
            private void MenuHint_Hint(object sender, EventArgs e)
            {
                toolStripStatusLabel1.Text = (sender as ToolStripMenuItem).Text;
            }
    
            private void TraverseMenuItemHint(ToolStripMenuItem element)
            {
                for (int i = 0; i < element.DropDownItems.Count; i++)
                {
                    if (!(element.DropDownItems[i] is ToolStripSeparator))
                    {
                        ToolStripMenuItem item = element.DropDownItems[i] as ToolStripMenuItem;
                        if (item.Text.Length > 0)
                            item.MouseEnter += MenuHint_Hint;
                        TraverseMenuItemHint(item);
                    }
                }
            }
    
            private void fileToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
            {
                toolStripStatusLabel1.Text = "Ready...";
        }
