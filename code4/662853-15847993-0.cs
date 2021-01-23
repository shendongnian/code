    private void dgvResults_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        int currentMouseOverRow = dgvResults.HitTest(e.X, e.Y).RowIndex;
        dgvResults.ClearSelection();
        if (currentMouseOverRow >= 0) // will show Context Menu Strip if not negative
        {
          dgvResults.Rows[currentMouseOverRow].Selected = true;
          cmsResults.Show(dgvResults, new Point(e.X, e.Y));
           row = currentMouseOverRow;
        }
      }
    }
