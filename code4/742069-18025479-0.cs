        if (dt.Rows.Count > 0)
        {
          newDataTable = dt.AsEnumerable()
                        .Where(r => !ListLinkedIds.Contains(r.Field<int>("LinkedTicketId")))
                        .CopyToDataTable();  
    
          gvMain.DataSource = newDataTable;
          gvMain.DataBind();
        }
        else {
        //error
        }
