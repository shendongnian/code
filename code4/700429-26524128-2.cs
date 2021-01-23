    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)  
    {  
        if (dataGridView1.Rows[e.RowIndex].DataBoundItem != null &&   
            dataGridView1.Columns[e.ColumnIndex].DataPropertyName.Contains("."))  
        {  
            e.Value = BindProperty(dataGridView1.Rows[e.RowIndex].DataBoundItem,
                dataGridView1.Columns[e.ColumnIndex].DataPropertyName);  
        }  
    }  
    private string BindProperty(object property, string propertyName)  
    {  
        string retValue = "";  
        if (propertyName.Contains("."))  
        {  
            PropertyInfo[] arrayProperties;  
            string leftPropertyName;  
            leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));  
            arrayProperties = property.GetType().GetProperties();  
            foreach (PropertyInfo propertyInfo in arrayProperties)  
            {  
                if (propertyInfo.Name == leftPropertyName)  
                {  
                    retValue = BindProperty(propertyInfo.GetValue(property, null),   
                    propertyName.Substring(propertyName.IndexOf(".") + 1));  
                    break;  
                }  
            }  
        }  
        else  
        {  
            Type propertyType;  
            PropertyInfo propertyInfo;  
            propertyType = property.GetType();  
            propertyInfo = propertyType.GetProperty(propertyName);  
            retValue = propertyInfo.GetValue(property, null).ToString();  
        }  
        return retValue;  
    }  
