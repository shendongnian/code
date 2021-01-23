    DataTable tblFiltered = dtt.Clone(); // clones only structure not data
    var filteredRows = dtt.AsEnumerable()
        .Where(row => row.Field<decimal>("Price") >= priceFrom 
                   && row.Field<decimal>("Price") <= priceTo));
    if(filteredRows.Any())
    {
        tblFiltered = filteredRows.CopyToDataTable();
    }
