     protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert") //- this is needed to explain that the INSERT command will only work when INSERT is clicked
            {
                dbcon.Execute("INSERT INTO PROJ_ASP (TRANS_CD) VALUES('')", "ProjectASPConnectionString");
    
                gv.DataBind();
                gv.EditIndex = gv.Rows.Count-1;
                gv.DataBind();
            }
    
        }
