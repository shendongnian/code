    void dg_MouseMove(object sender, MouseEventArgs e) {
      this.toolTip1.Hide(dg);
      this.toolTip1.RemoveAll();
      System.Windows.Forms.DataGrid.HitTestInfo myHitTest = dg.HitTest(e.X, e.Y);
      if (myHitTest.Row > -1) {
        this.toolTip1.SetToolTip(dg, "Over " + dt.Rows[myHitTest.Row][0].ToString());
        this.Text = "Over " + dt.Rows[myHitTest.Row][0].ToString();
      }
    }
