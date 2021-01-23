    List<DataGridView> Grids = new List<DataGridView>();
    // Assigning new DataGridViews
    for (int i = 0; i < 5; i++)
      Grids.Add(new DataGridView());
    // Fetching one
    DataGridView fetched = Grids[2];
