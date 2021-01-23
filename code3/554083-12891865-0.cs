    private bool toggle = false;
    myGrid.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(myClass_ColumnHeaderMouseClick);
    private void myClass_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      foreach(DataGridViewCell cell in (DataGridView)sender.cells)
      {
        if(toggle)
          cell.Value = 1;
        else
          cell.Value = 0;
      }
      
      if(toggle)
        toggle = false;
      else
        toggle = true;
    }
