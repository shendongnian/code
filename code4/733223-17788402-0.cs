      private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
      {
        dataGridView2.Visible = true;
        Point point = new Point(dataGridView2.PointToClient(new Point(e.X, e.Y)));
        DataGridView.HitTestInfo hti = dataGridView2.HitTest(point.X, point.Y);
        int row = hti.RowIndex;
      }
