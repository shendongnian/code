    DataGridView gridView = sender as DataGridView;
    
        if (null != gridView)
        {
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }
