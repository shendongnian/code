    public void DownloadOfflineAuditSheetEditor(object s, EventArgs e)
    {
       GenerateRealTimeContent();
       Response.AppendHeader("content-disposition", "attachment; filename=thefile.html");
       Response.WriteFile(Server.MapPath("~/thefile.html"), true);
       Response.End();
    }
