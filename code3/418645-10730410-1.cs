    foreach (DataGridColumn col in dataGrid1.Columns)
            {
                if (col.GetType() == typeof(DataGridTextColumn))
                {
                    col.IsReadOnly = true;
                }
                else
                {
                    col.IsReadOnly = false;
                }
            }
