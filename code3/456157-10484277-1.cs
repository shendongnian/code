     private void dataGrid1_KeyUp(object sender, KeyEventArgs e)
            {
                DependencyObject dep = (DependencyObject)e.OriginalSource;
                //here we find the Row is selected
                //then we check is the row last row
                
                while ((dep != null) && !(dep is DataGridRow) && !(dep is DataGridColumnHeader))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
    
                if (dep == null)
                    return;
    
                if (dep is DataGridRow)
                {
                    DataGridRow row= dep as DataGridRow;
                    
                   if (row.GetIndex() == dataGrid1.Items.Count - 1)
                {
                    dataGrid1.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                    dataGrid1.UnselectAll();
                }
                }
            }
