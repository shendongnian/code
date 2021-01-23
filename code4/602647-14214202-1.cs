    private void dataGridView_Routes_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {
                    // The mouse locations are relative to the screen, so they must be 
                    // converted to client coordinates.
                    Point clientPoint = dataGridView_Routes.PointToClient(new Point(e.X, e.Y));
                    // If the drag operation was a copy then add the row to the other control.
                    if (e.Effect == DragDropEffects.Copy)
                    {
                        DataGridViewRow Row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                        dataGridView_Routes.Rows.Add(Row.Cells[0].Value, Row.Cells[1].Value, Row.Cells[2].Value);
                    }
                }
                else
                {
                    log("Geen data! #01", "Fout");
                }
            }
            catch (Exception msg)
            {
                log(msg.Message,"Fout");
            }
        }
