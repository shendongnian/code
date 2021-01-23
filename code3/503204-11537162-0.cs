    var blackOutFromDate = DateTime.Parse(CheckInDate.Text);
    var blackOutToDate = DateTime.Parse(CheckOutDate.Text);
    var filteredRows =  _blackOutTable
        .AsEnumerable()
        .Where(r => r.Field<DateTime>("FromDate") >= blackOutFromDate && r.Field<DateTime>("ToDate") <= blackOutToDate);
    
    if(filteredRows.Any())
    {
        // do something...
    }
  
