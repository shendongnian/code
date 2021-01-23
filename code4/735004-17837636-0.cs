    private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        // Modify the header of the Name column.
        if (e.Column.Header.ToString() == "Name")
            e.Column.Header = "Task";
        // Replace the DueDate column with a custom template column.
        if (e.PropertyName == "DueDate")
        {
            // Create a new template column.
            DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
            templateColumn.Header = "Due Date";
            templateColumn.CellTemplate = (DataTemplate)Resources["dueDateCellTemplate"];
            templateColumn.CellEditingTemplate = (DataTemplate)Resources["dueDateCellEditingTemplate"];
            templateColumn.SortMemberPath = "DueDate";
            // ...
            // Replace the auto-generated column with the templateColumn.
            e.Column = templateColumn;
        }
        // Cancel AutoGeneration of all boolean columns.
        if (e.PropertyType == typeof(bool))
            e.Cancel = true;
    }
