    foreach(BoundField b in grid.Columns)
    {
       if(b.HeaderText == 'y')
       {
          b.HeaderText = "new y";
       } else {
          b.Visible = false;
       }
    }
