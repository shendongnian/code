    Column1.DataPropertyName = "Transfer";
    Column2.DataPropertyName = "Source";
    Column3.DataPropertyName = "Destination";
    Column3.DataSource = new List<string>() { "aaa", "bbb", "ccc" }; 
    List<Mine> grid = new List<Mine>();
    grid.Add(new Mine() { Transfer = true, Source = "xxx", Destination = "bbb" });
    grid.Add(new Mine() { Transfer = false, Source = "yyy", Destination = "aaa" });
    grid.Add(new Mine() { Transfer = true, Source = "zzz", Destination = "ccc" });
    dataGridView1.DataSource = grid;
