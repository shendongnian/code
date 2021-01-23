    DataTable yourDataTable = new DataTable();
    var result = yourDataTable.AsEnumerable()
                            .Take(2)   //Select first two rows
                            .Select(r =>
                                new
                                {
                                    Field1 = r.Field<int>("col1"),    //Select your columns
                                    Field2 = r.Field<string>("col2")
                                    //your rest of the columns
                                }
                                    );
