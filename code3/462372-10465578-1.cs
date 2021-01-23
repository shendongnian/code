    private void XrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        ((XRLabel)sender).Tag = GetCurrentColumnValue("ID");
    }
    
    private void XrLabel1_HtmlItemCreated(object sender, DevExpress.XtraReports.UI.HtmlEventArgs e)
    {
        e.ContentCell.InnerHtml = String.Format("<a href=http://www.testarea.com/property.aspx?id={1}>{0}</a>", e.ContentCell.InnerText, e.Data.Tag);
    }
