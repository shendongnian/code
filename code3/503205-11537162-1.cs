    DataTable tblFiltered;
    var invCulture=System.Globalization.CultureInfo.InvariantCulture;
    var filteredRows = _blackOutTable.AsEnumerable()
        .Where(r => DateTime.Parse(r.Field<String>("FromDate"), invCulture) >= blackOutFromDate
                 && DateTime.Parse(r.Field<String>("ToDate"),   invCulture) <= blackOutToDate);
    
    if (filteredRows.Any())
    {
        tblFiltered = filteredRows.CopyToDataTable();
    }
  
