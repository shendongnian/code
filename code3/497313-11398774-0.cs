        // Init Code
        contextMenuStrip1.Cursor = Cursors.Hand;
        recentMessagesToolStripMenuItem.MouseLeave += new EventHandler(SetCursorToHandOn_MouseLeave);
        recentMessagesToolStripMenuItem.MouseEnter += new EventHandler(SetCursorToArrowOn_MouseEnter);
    
        private void SetCursorToArrowOn_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip1.Cursor = Cursors.Arrow;
        }
        private void SetCursorToHandOn_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Cursor = Cursors.Hand;
        }
