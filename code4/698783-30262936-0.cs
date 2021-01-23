    // handle right mouse click to select the correct item for context menu usage
        private void myDataGrid_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //find the clicked row
            DataGridRow row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement) sender, e.GetPosition(myDataGrid));
            if (row == null)
            {
                Debug.WriteLine("Row is null");
                return;
            }
            else
            {
                Debug.WriteLine("Grid Row Index is " + row.GetIndex().ToString());
                (sender as DataGrid).SelectedIndex = row.GetIndex();
            }
        }
