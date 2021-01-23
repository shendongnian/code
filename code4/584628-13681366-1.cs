 public void ExportToExcel(DataTable dt, string fileName)
    {
        try
        {
            //**************************Excel Generation starts***************************
            string attachment = "attachment; filename="+fileName+".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int ik;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (ik = 0; ik < dtDCItems.Columns.Count; ik++)
                {
                    Response.Write(tab + dr[ik].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
       
            //**************************Excel Generation Ends***************************
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ERROR";
        }
    }
