    protected void Page_Load(object sender, EventArgs e)
    {
         Response.Clear();
         Response.ClearHeaders();
         Response.ClearContent();
         Response.AddHeader("content-disposition", "attachment; filename=" + Session["OUTPUTFILE"].ToString()+ ".xls");
         Response.AddHeader("Content-Type", "application/Excel");
         Response.ContentType = "application/ms-excel.xls";
         Response.AddHeader("Content-Length", file_New.Length.ToString());
         Response.WriteFile(file_New.FullName);
         Response.Flush();
         file_New.Delete();
    }
