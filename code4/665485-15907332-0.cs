      private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(bool?))
            {
                 DataGridCheckBoxColumn  checkBoxColumn=new DataGridCheckBoxColumn();
                checkBoxColumn.Header = e.Column.Header;
                checkBoxColumn.Binding = new Binding(e.PropertyName);
                checkBoxColumn.IsThreeState = true;
                // Replace the auto-generated column with the checkBoxColumn.
                e.Column = checkBoxColumn;
               }
        }
