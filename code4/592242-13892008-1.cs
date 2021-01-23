    private void myData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
    {
                foreach (var item in myData.Columns)
                {
                    item.HeaderStyle = null;
                }
    
                if (myData.SelectedCells != null && myData.SelectedCells.Count != 0)
                {
                    Style styleSelected = new Style();
                    styleSelected.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(Colors.Orange)));
    
                    foreach (var item in myData.SelectedCells)
                    {
                        item.Column.HeaderStyle = styleSelected;
                    }
                }
      }       
         
