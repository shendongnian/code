        dataGridView1.DataSource = data;
        For Each dc as DataColumn in dt.Columns
            dc.ReadOnly = true
        Next
        dataGridView1.AllowUserToAddRows = true; 
        // dataGridView1.ReadOnly = true;
        dataGridView1.Columns[0].Visible = true;
        dataGridView1.Columns[1].Width = 340;
        dataGridView1.Columns[2].Width = 55;          
        deleteck = new DataGridViewCheckBoxColumn();
        deleteck.HeaderText = "delete";     
        deleteck.Width = 80;
        deleteck.ReadOnly = false;         
        dataGridView1.Columns.Insert(0, deleteck);
