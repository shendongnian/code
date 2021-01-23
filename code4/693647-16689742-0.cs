    protected void lnkDownload_Click(object sender, eventArgs e)
    {
       LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string filePath = ((HtmlInputHidden)gvFilesDetails.Rows[gvrow.RowIndex].FindControl("hdnFileLocation")).Value.ToString();
            string fileURL = ConfigurationManager.AppSettings["FileURL"].ToString();
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(fileURL+filePath);
            Response.End();
    }
 
