     private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
      {                
               if (e.PropertyName == "System.DateTime")
                {
                    // Create a new template column.
                    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                    templateColumn.CellTemplate = ......
                    templateColumn.CellEditingTemplate = .....
                    e.Column = templateColumn;
                }            
      }
