        public static void OnHoldCheckClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridViewEventCheckBoxCell)
            {
                DataGridViewEventCheckBoxCell cell = sender as DataGridViewEventCheckBoxCell;
                if (!cell.ReadOnly)
                {
                    // The rows in the DataGridView are bound to Specimen objects
                    Specimen specimen = (Specimen)cell.OwningRow.DataBoundItem;
                    // Modify the underlying data source
                    if ((bool)cell.EditedFormattedValue)
                        specimen.IsReleased = false;
                    else if (specimen.WasReleased)
                        specimen.IsReleased = true;
                    // Then invalidate the cell in the other column to force it to redraw
                    DataGridViewCell releasedCell = cell.OwningRow.Cells["IsReleased"];
                    cell.DataGridView.InvalidateCell(releasedCell);
                }
            }
        }
