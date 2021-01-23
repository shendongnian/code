    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
          DataGridBoundColumn col = e.Column as DataGridBoundColumn;
         //set visiblity by doing the code you wnat ..i.logic to hide column
          if (col.Header.ToString().ToLower() == "id") 
            { 
                col.Visibility = System.Windows.Visibility.Hidden;
            }
    }
