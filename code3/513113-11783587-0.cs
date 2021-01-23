    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
             log slog = new log();
    
             slog.Date = dr.cells(0).Value.ToString();
             slog.Level = dr.cells(1).Value.ToString();
             slog.Project = dr.cells(2).Value.ToString();
             slog.Number = dr.cells(3).Value.ToString();
             slog.Method = dr.cells(4).Value.ToString();
             slog.Property = dr.cells(5).Value.ToString();
    
             logEntity.logs.AddObject(slog);
    
            }
    logEntity.SaveChanges();
          
