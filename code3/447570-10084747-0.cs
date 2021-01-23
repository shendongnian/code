    // Create a Hyperlink Web server control and add it to the cell.
    System.Web.UI.WebControls.HyperLink h = new HyperLink();
    h.Text = item.Value;
    h.NavigateUrl = item.Value;
    celula.Controls.Add(h);
