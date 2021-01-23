    TimeSpan sum = TimeSpan.Zero;
    for ( int i = 0; i < grid_horas.Rows.Count; i++ )
    {
       sum += (TimeSpan)grid_horas.Rows[i].Cells[7].Value;
    }
    // now use sum.Hours, sum.TotalHours, sum.Minutes etc
