    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
      if (e.PropertyName == "CustomerID")
      {
        DataGridComboBoxColumn column = new DataGridComboBoxColumn();
     
        column.DataFieldBinding = new Binding("CustomerID");
     
        column.DataFieldTarget = ComboBoxDataFieldTarget.SelectedValue;
     
        column.ItemsSource = DBAccess.GetCustomers().Tables["Customers"].DefaultView;
     
        column.EditingElementStyle = (Style)this.RootGrid.FindResource("CustomerFKStyle");
     
        e.Column = column;
      }
    }
