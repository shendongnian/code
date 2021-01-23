    protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
      this.ClearSelection();
      for (int i = 0; i < this.Columns.Count; ++i) {
        this.Rows[e.RowIndex].Cells[i].Selected = true;
      }
      base.OnRowHeaderMouseClick(e);
    }
    protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
      this.ClearSelection();
      for (int i = 0; i < this.Rows.Count; ++i) {
        this.Rows[i].Cells[e.ColumnIndex].Selected = true;
      }
      base.OnColumnHeaderMouseClick(e);      
    }
