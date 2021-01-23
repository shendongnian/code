        TableLayoutPanel tlp;
        bool resizing;
        int rowindex = -1;
        int nextHeight;
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                resizing = true;
            }
        }
        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            if (!resizing)
            {
                rowindex = -1;
                tlp.Cursor = Cursors.Default;
                if (e.Y <= 3)
                {
                    rowindex = tlp.GetPositionFromControl(c).Row - 1;
                    if (rowindex >= 0)
                        tlp.Cursor = Cursors.HSplit;
                }
                if (c.Height - e.Y <= 3)
                {
                    rowindex = tlp.GetPositionFromControl(c).Row;
                    if (rowindex < tlp.RowStyles.Count)
                        tlp.Cursor = Cursors.HSplit;
                }
            }
            if (resizing && rowindex > -1)
            {
                nextHeight = e.Y;
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (nextHeight > 0)
                    tlp.RowStyles[rowindex].Height = nextHeight;
                resizing = false;
            }
        }
