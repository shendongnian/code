            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mStrip = new ContextMenuStrip();
                mStrip.Closing += new ToolStripDropDownClosingEventHandler(mStrip_Closing);
                foreach (Control cntrl in this.Controls)
                {
                    ToolStripMenuItem itm = new ToolStripMenuItem();
                    itm.Text = cntrl.Text;
                    itm.CheckOnClick = true;
                    itm.Checked = cntrl.Visible;
                    
                    mStrip.Items.Add(itm);
                    mStrip.Show(this.PointToScreen(new Point(_mouseX, _mouseY)));
                }
            }
            private void mStrip_Closing(Object sender, ToolStripDropDownClosingEventArgs e)
            {
                if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                    e.Cancel = true;
            }
