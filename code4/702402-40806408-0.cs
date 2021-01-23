        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabCount; ++i)
                {
                    Rectangle r = tabControl1.GetTabRect(i);
                    if (r.Contains(e.Location) /* && it is the header that was clicked*/)
                    {
                        // Change slected index, get the page, create contextual menu
                        ContextMenu cm = new ContextMenu();
                        // Add several items to menu
                        cm.MenuItems.Add("hello");
                        cm.MenuItems.Add("world!");
                        cm.Show(tabControl1, e.Location);
                        break;
                    }
                }
            }
        }
