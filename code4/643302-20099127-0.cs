    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("Range", typeof(int));
    dc.ExtendedProperties.Add("Min", 0);
    dc.ExtendedProperties.Add("Max", 10);
    dt.Columns.Add(dc);
    dt.ColumnChanging += dt_ColumnChanging;
