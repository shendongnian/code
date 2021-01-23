    var dataTable = new DataTable();
    dataTable.Columns.AddRange( new DataColumn[]{ 
        new DataColumn("LastName" , typeof(string)),
        new DataColumn("FirstName" , typeof(string)),
        new DataColumn("Phone" , typeof(string)),
        new DataColumn("City" , typeof(string)),
        new DataColumn("PositionApplied" , typeof(string)),
        new DataColumn("Status" , typeof(string)),
        new DataColumn("CallDate" , typeof(string)),
        new DataColumn("CellOrPager" , typeof(string)),
        new DataColumn("Gender" , typeof(string))
    });
