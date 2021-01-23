    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
            {
                var cms = sender as ContextMenuStrip;
                var mousepos = Control.MousePosition;
                if (cms != null)
                {
                    var rel_mousePos = cms.PointToClient(mousepos);
                    if (cms.ClientRectangle.Contains(rel_mousePos))
                    {
                        //the mouse pos is on the menu ... 
                        //looks like the mouse was used to open it
                        var dgv_rel_mousePos = dataGridView1.PointToClient(mousepos);
                        var hti = dataGridView1.HitTest(dgv_rel_mousePos.X, dgv_rel_mousePos.Y);
                        if (hti.RowIndex == -1)
                        { 
                            // no row ...
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        //looks like the menu was opened without the mouse ...
                        //we could cancel the menu, or perhaps use the currently selected cell as reference...
                        e.Cancel = true;
                    }
                }
            }
