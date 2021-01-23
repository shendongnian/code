     private void gen_AutoGridColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {           
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            if (desc.Attributes[typeof(ColumnNameAttribute)] is ColumnNameAttribute att) e.Column.Header = att.Name;
    
            //set the width for each column           
            e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);            
        }
