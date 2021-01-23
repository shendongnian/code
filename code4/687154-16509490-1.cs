    var column = new DataGridViewComboBoxColumn();
    
    column.DataSource = data.Tables[0].AsEnumerable().
          Select(genre => new { genre = genre.Field<string>("genre") }).Distinct();
    column.DataPropertyName = "genre";
    column.DisplayMember = "genre";
    column.ValueMember = "genre";
    grid.DataSource = data.Tables[0];
    // Instead of the below line, You could use grid.Columns["genre"].Visible = false;
    grid.Columns.Remove("genre");  
    grid.Columns.Add(column);  
