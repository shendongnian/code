    private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
      {                
               if (e.PropertyName == "System.DateTime")
                {
                    // Create a new template column.
                    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                    templateColumn.CellTemplate = (DataTemplate)Resources["dueDateCellTemplate"];
                    templateColumn.CellEditingTemplate = (DataTemplate)Resources["dueDateCellEditingTemplate"];
                    e.Column = templateColumn;
                }            
      }
