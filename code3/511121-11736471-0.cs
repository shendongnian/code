    foreach (Control item in this.Controls)
    {
      if (item is Window 
          && item.Id != yourWindow )
      {
         item.Enabled = false;
      }
    }
