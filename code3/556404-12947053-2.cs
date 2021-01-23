     DataTable dt = new DataTable(); 
            DataColumn[] dcs = new DataColumn[]{}; 
     
            foreach (DataGridViewColumn c in dgv.Columns) 
            { 
                DataColumn dc = new DataColumn(); 
                dc.ColumnName = c.Name; 
                dc.DataType = c.ValueType; 
                dt.Columns.Add(dc); 
     
            } 
     
            foreach (DataGridViewRow r in dgv.Rows) 
            { 
                DataRow drow = dt.NewRow(); 
     
                foreach (DataGridViewCell cell in r.Cells) 
                { 
                    drow[cell.OwningColumn.Name] = cell.Value; 
                } 
     
                dt.Rows.Add(drow); 
            } 
