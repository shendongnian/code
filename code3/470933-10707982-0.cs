    protected void RowBound(object sender, GridItemEventArgs e)
    {
       if (e.Item is GridNestedViewItem)
       {
          GridNestedViewItem item = e.Item as GridNestedViewItem;
       }
    }
