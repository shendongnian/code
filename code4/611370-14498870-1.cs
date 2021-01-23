    private void dataGridView_MouseClick( object sender, MouseEventArgs e ) {
      DataGridView dgv = (DataGridView)sender;
      if (dgv.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader) {
        dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
        dgv.EndEdit();
      } else {
        dgv.EditMode = DataGridViewEditMode.EditOnEnter;
      }
    }
