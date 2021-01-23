    DataTable dt = new DataTable();
    dt.Columns.Add("Cost", typeof(System.Decimal));
    dt.Rows.Add(1M);
    dt.Rows.Add(3.25M);
    dt.Rows.Add(0.75M);
    
    decimal TotalCost = (decimal)dt.Compute("Sum(Cost)", "");
