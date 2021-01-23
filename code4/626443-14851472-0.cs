        grv1.AutoGenerateColumns = false;
        grv1.DataSource = ds.Tables[0];        
        grv1.Columns[0].DataPropertyName = "LastName";
        DataGridViewTextBoxColumn nrCol = new DataGridViewTextBoxColumn();
        nrCol.Name = "Nr";
        nrCol.HeaderText = "Nr";
        grv1.Columns.Insert(0, nrCol);
        grv1.Columns[0].ReadOnly = false;
        
        //!!!!!!!!!!!!!!!!!!!!!!
        grv1.Columns[0].DataPropertyName = "Postal code"; //or whatever existing column 
        for (int i=0;i<grv.Rows.Count;i++)
        {
            grv.Rows[i].Cells[0].Value = i.ToString();       
        }
