    private void MyWPFFrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.SortMemberPath.Equals("EndDate"))
            {
                if (((MyObject)e.Row.Item).EndDate.Equals(DateTime.MinValue))
                {
                    ((MyObject)e.Row.Item).Completed = 1;
                    ((MyObject)e.Row.Item).CompletedDescription = "YES";
                }
                else
                {
                    ((MyObject)e.Row.Item).Completed = 0;
                    ((MyObject)e.Row.Item).CompletedDescription = "NO";
                }
                
                this.MyWPFFrid.CurrentItem = ((MyObject)e.Row.Item);
           
                
                if (!e.Row.IsEditing)
                {
                    this.MyWPFFrid.Items.Refresh();
                }
                
              
            }
        }
