    protected void btnPrint_Click(object sender, EventArgs e)
    {
     url = "~/Gui/Report/ReportViewer.aspx?ReportName=CustomerReport";
     Page page = (Page)HttpContext.Current.Handler;
     url = page.ResolveUrl(url);
     string script = "window.open('" + url + "');";
     System.Text.StringBuilder sb = new System.Text.StringBuilder();
     sb.Append("<script language='javascript'>");
     sb.Append(script);
     sb.Append("</script>");
     ScriptManager.RegisterStartupScript(page,
         typeof(Page),
         "Redirect",
         script,
         false);
    }
 
