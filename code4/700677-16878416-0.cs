     protected void dgData_RowDataBound(object sender, GridViewRowEventArgs e)
     {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl;
                if (e.Row.RowIndex == 0)
                {
                    for (Int32 i = 0; i < e.Row.Cells.Count; i++)
                    {
                        ddl = new DropDownList();
                        ddl.ID = "ddlCol" + i.ToString ();
                        e.Row.Cells[i].Controls.Add(ddl);
                    }
                }
           }
    }
