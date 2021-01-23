    // Create a Hyperlink Web server control and add it to the cell.
    System.Web.UI.WebControls.HyperLink h = new HyperLink();
    h.Text = item.Value;
    string url = "~/Default.aspx?Item=" + Server.UrlEncode(item.Value);
    h.NavigateUrl = url;
    celula.Controls.Add(h);
