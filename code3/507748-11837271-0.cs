    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    
            if (e.CommandName == "Insert") //- this is needed to explain that the INSERT command will only work when INSERT is clicked
            {
                gv.DataBind();
    
                DataTable d = dbcon.GetDataTable("SELECT * FROM CIS.CIS_TRANS ORDER BY ID DESC", "ProjectCISConnectionString");
    
                string transCode = "", fundCode = "", BSA_CD = "", DP_TYPE = "";
    
                if (d.Rows.Count > 0)
                {
                    transCode = d.Rows[0]["TRANS_CD"].ToString();
                    fundCode = d.Rows[0]["FUND_CD"].ToString();
                    BSA_CD = d.Rows[0]["BSA_CD"].ToString();
                    DP_TYPE = d.Rows[0]["DP_TYPE"].ToString();
    
                    if (transCode.Trim().Length > 0)
                    {
                        dbcon.Execute("INSERT INTO CIS.CIS_TRANS (TRANS_CD) VALUES('')", "ProjectCISConnectionString");
    
                        gv.DataBind();
                    }
                }
    
                gv.EditIndex = gv.Rows.Count - 1;
    
            }
            else if (e.CommandName == "Cancel")
            {
                DataTable d = dbcon.GetDataTable("SELECT * FROM CIS.CIS_TRANS ORDER BY ID DESC", "ProjectCISConnectionString");
    
                string transCode = "";
    
                if (d.Rows.Count > 0)
                {
                    transCode = d.Rows[0]["TRANS_CD"].ToString();
    
                    if (transCode.Trim().Length == 0)
                    {
                        dbcon.Execute(string.Format("DELETE CIS.CIS_TRANS WHERE ID = '{0}'", d.Rows[0]["ID"]), "ProjectCISConnectionString");
    
                        gv.DataBind();
                    }
                }
    
    
            }
        }
