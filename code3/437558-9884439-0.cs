       private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
        int rowIndex = this.DataGridForEvents.SelectedIndex;
        List<DataGridRow> rows = GetRows();
        rows[rowIndex].DetailsVisibility = Visibility.Visible;
        }
    
    private void Expander_Collapsed(object sender, RoutedEventArgs e)
    {
    int rowIndex = this.DataGridForEvents.SelectedIndex;
    List<DataGridRow> rows = GetRows();
    rows[rowIndex].DetailsVisibility = Visibility.Collapsed;
    }
    
    
    
    public List<DataGridRow>  GetRows()
    {
    List<DataGridRow> rows = new List<DataGridRow>();
    foreach (var rowItem in this.DataGridForEvents.ItemsSource)
    {
    this.DataGridForEvents.ScrollIntoView(rowItem, this.DataGridForEvents.Columns.Last());
    FrameworkElement el = this.DataGridForEvents.Columns.Last().GetCellContent(rowItem);
    DataGridRow row = DataGridRow.GetRowContainingElement(el.Parent as FrameworkElement);
    if (row != null)
    rows.Add(row);
    }
    return rows;
    }
