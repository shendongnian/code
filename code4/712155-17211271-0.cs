            private void grdSchedules_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int currentMouseOverRow = grdSchedules.HitTest(e.X, e.Y).RowIndex;
    
                    for (int x = 0; x < grdSchedules.Rows.Count; x++)
                    {
                        if (grdSchedules.Rows[x].Index == currentMouseOverRow)
                        {
                            grdSchedules.Rows[x].Selected = true;
                        }
                        else
                        {
                            grdSchedules.Rows[x].Selected = false;
                        }                    
                    }
    
                    contextMenu.Show(grdSchedules, new Point(e.Y, e.Y));
                    
                }
            }
