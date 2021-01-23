        private void DragMove_MouseMoveHandler(object sender, MouseEventArgs e)
        {
            Control dgrid = sender as Control;
            
            Point now = dgrid.PointToClient(Cursor.Position);
            if (e.Button == MouseButtons.Left)
            {
                Control under = dgrid.GetChildAtPoint(now);
                if (under != null && under.GetType() == typeof(CheckBox))
                {
                    //if the point has a valid CheckBox control under it
                    CheckBox box = under as CheckBox;
                    if (box.Tag == null)// not yet been swiped
                    {
                        box.Checked = !box.Checked;
                        box.Tag = true;
                    }
                }
            }
            else
            {
                //if MouseButtons no longer registers as left
                //remove the handler and reset the tags
                dgrid.MouseMove -= DragMove_MouseMoveHandler;
                foreach (CheckBox box in c.Controls.OfType<CheckBox>())
                {
                    box.Tag = null; //reset for next time
                }
            }
        }
