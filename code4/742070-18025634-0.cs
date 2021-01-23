    var newDataTable = dt.Clone();  // an empty table with the same schema
    var ticketRows = dt.AsEnumerable()
        .Where(r => !ListLinkedIds.Contains(r.Field<int>("LinkedTicketId")));
    if(ticketRows.Any())
        newDataTable = ticketRows.CopyToDataTable();
