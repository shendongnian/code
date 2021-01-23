    var numbersFirst6digits = TableNumber.AsEnumerable()
        .Select(r => new string(r.Field<string>("MobileNumbers").Where(Char.IsDigit).Take(6).ToArray()));
    var dictionary = new HashSet<string>(numbersFirst6digits);
    var validCodeRows = from row in TableCode.AsEnumerable()
                        join num in dictionary
                        on row.Field<string>("MobileCode") equals num
                        select row;
    // if you need a new DataTable:
    DataTable tblValidCodes = validCodeRows.CopyToDataTable();
