            private void copyNotesToClipboardStripMenu_Click(object sender, EventArgs e)
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                if (menuItem != null)
                {
                    ContextMenuStrip calendarMenu = menuItem.Owner as ContextMenuStrip;
                    if (calendarMenu != null)
                    {
                        Control controlSelected = calendarMenu.SourceControl;
                    }
                }
            }
