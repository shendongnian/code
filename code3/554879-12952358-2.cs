    private void clearGrid(DataGridView view) {
        for (int row = 0; row < view.Rows.Count; ++row) {
            bool isEmpty = true;
            for (int col = 0; col < view.Columns.Count; ++col) {
                object value = view.Rows[row].Cells[col].Value;
                if (value != null && value.ToString().Length > 0) {
                    isEmpty = false;
                    break;
                }
            }
            if (isEmpty) {
                view.Rows.RemoveAt(row);
            }
        }
    }
