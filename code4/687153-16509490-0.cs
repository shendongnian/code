    var column = new DataGridViewComboBoxColumn();
    
    column.DataSource = data.Tables[0].AsEnumerable().
          Select(genre => new { genre = genre.Field<string>("genre") }).Distinct();
    column.DataPropertyName = "genre";
    grid.DataSource = data.Tables[0];
    grid.Columns.Remove("genre");  
    grid.Columns.Add(column);  
