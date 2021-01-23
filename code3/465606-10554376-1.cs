        // Add a button column. 
        DataGridViewButtonColumn buttonColumn = 
            new DataGridViewButtonColumn();
        buttonColumn.HeaderText = "";
        buttonColumn.Name = "Open";
        buttonColumn.Text = "Open";
        buttonColumn.UseColumnTextForButtonValue = true;
        dataGridView1.Columns.Add(buttonColumn);
