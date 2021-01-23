    // This creates an empty DataTable with the same structure as objdatatable2.
    DataTable dt = objdatatable2.Clone();
    
    var results = objdatatable2.AsEnumerable().Where(r2 => !objdatatable1.AsEnumerable().Any(r1 => (r2.Field<string>("market_id") == r1.Field<int>("market_id").ToString())));
    // Copy results to the DataTable only if there are results.
    if (results.Count() > 0) {
        dt = results.CopyToDataTable();
    }
    
