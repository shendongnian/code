    private void ExportToExcell()
    {       
            DataTable dt = new DataTable();
            dt.Columns.Add("Plan ID");
            dt.Columns.Add("Plan Name");
            dt.Columns.Add("Balance");
            foreach (GridViewRow row in gdvBal.Rows)
            {
                CheckBox chkCalls = (CheckBox)row.FindControl("chkCalls");
                if (chkCalls.Checked == true)
                {
                    int i = row.RowIndex;
                    Label lblPlanId = (Label)gdvBal.Rows[i].FindControl("lblPlanId");
                    Label lblPlanName = (Label)gdvBal.Rows[i].FindControl("lblPlanName");
                    Label lblBalance = (Label)gdvBal.Rows[i].FindControl("lblBalance");
    
                    DataRow dr = dt.NewRow();
                    dr["Plan ID"] = Convert.ToString(lblPlanId.Text);
                    dr["Plan Name"] = Convert.ToString(lblPlanName.Text);
                    dr["Balance"] = Convert.ToString(lblBalance.Text);
                    dt.Rows.Add(dr);
                }
            }
            GridView gdvExportxls = new GridView();
            gdvExportxls.DataSource = dt;
            gdvExportxls.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", string.Format("attachment;filename=BillingForfBalances.xls", "selectedrows"));
            Response.Charset = "";
            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmlwriter = new HtmlTextWriter(stringwriter);
            gdvExportxls.RenderControl(htmlwriter);
            Response.Write(stringwriter.ToString().Replace("<div>", " ").Replace("</div>", " "));
            Response.End();
    
    }
