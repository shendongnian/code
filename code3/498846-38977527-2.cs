    protected void grdPatsCliente_RowCreated(object sender, GridViewRowEventArgs e) {
        if (e.Row.RowType == DataControlRowType.Pager) {
            int i = 0;
            foreach (Control ctl in e.Row.Cells[0].Controls[0].Controls[0].Controls) {
                i++;
                if (ctl.Controls[0].GetType().ToString() == "System.Web.UI.WebControls.DataControlPagerLinkButton") {
                    LinkButton lnk = (LinkButton)ctl.Controls[0];
                    if (lnk.Text == "...") {
                        if (i < 3) {
                            lnk.Text = "Prev";
                        } else {
                            lnk.Text = "Next";
                        }
                    }
                }
            }
        }
    }
