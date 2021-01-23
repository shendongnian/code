    DataTable dTable = new DataTable();
    DataColumn auto = new DataColumn("AutoID", typeof(System.Int32));
    dTable.Columns.Add(auto);
    auto.AutoIncrement = true;
    auto.AutoIncrementSeed = 1;
    auto.ReadOnly = true;
