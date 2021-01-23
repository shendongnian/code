    DataTable dt = LoadDataTable();
    using (DbDataReader dr = dt.CreateDataReader())
    {
        //Get Original Datatable structure
        dt = dt.Clone();
        // Add Auto Increment Column called ID
        dt.Columns.Add(new DataColumn("ID")
        {
            AutoIncrement = true,
            AllowDBNull = false,
            AutoIncrementSeed = 1,
            AutoIncrementStep = 1,
            DataType = typeof(System.Int32),
            Unique = true
        });
        // Change Auto Increment Column Ordinal Position to 0 (ie First Column)
        dt.Columns["TabID"].SetOrdinal(0);
        // Re-load original Data
        dt.Load(dr);
    }
