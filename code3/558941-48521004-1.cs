    Hi we can  use ToLower Method sometimes it is not filter.
    
      EmployeeId = Session["EmployeeID"].ToString();
     var rows = dtCrewList.AsEnumerable().Where
                (row => row.Field<string>("EmployeeId").ToLower()== EmployeeId.ToLower());
    
                    if (rows.Any())
                    {
                        tblFiltered = rows.CopyToDataTable<DataRow>();
                    }
