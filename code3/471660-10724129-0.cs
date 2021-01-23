    private void datagridSignal_MouseMove(object sender, MouseEventArgs e) 
    {
      this.toolTip.Hide(datagridSignal);
      this.toolTip.RemoveAll();
      System.Windows.Forms.DataGrid.HitTestInfo myHitTest;                 
      myHitTest = datagridSignal.HitTest(e.X, e.Y);
      this.toolTip.SetToolTip(datagridSignal, " ID = '" + 
                              ((int)datagridSignal[myHitTest.Row][0]).ToString() +
                               "'  '" + 
                              myHitTest.Row.ToString() + "'"); 
    } 
