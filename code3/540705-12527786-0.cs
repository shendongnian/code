    protected void gvCustomers_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow newHeaderRow = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell cell1 = new TableHeaderCell();
            cell1.ColumnSpan = 1; //e.Row.Cells.Count;
            cell1.Text = "";
            TableCell cell2 = new TableCell();
            cell2.ColumnSpan = 2;
            cell2.Text = "One";
            TableCell cell3 = new TableCell();
            cell3.ColumnSpan = 2;
            cell3.Text = "Two";
            TableCell cell4 = new TableCell();
            cell4.ColumnSpan = 2;
            cell4.Text = "Three";
            newHeaderRow.Cells.Add(cell1);
            newHeaderRow.Cells.Add(cell2);
            newHeaderRow.Cells.Add(cell3);
            newHeaderRow.Cells.Add(cell4);
            ((GridView)sender).Controls[0].Controls.AddAt(0, newHeaderRow);
        }
        
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //System.Text.StringBuilder sbNewHeader = new StringBuilder();
            //sbNewHeader.AppendFormat("&nbsp;</th>" +
            //    "<th colspan='2' class='tableColGroupAssociate'>Associate Info <a href='#' class='associateHide'> Hide </a> </th>" +
            //    "<th colspan='2' class='tableColGroupTransaction'>Financial Info <a href='#' class='financialHide'> Hide </a> </th>" +
            //    "<th colspan='2' class='tableColGroupDailyTax'>Tax Info <a href='#' class='dailyTaxHide'> Hide </a> </th>"
            //    + "</tr>");
            //sbNewHeader.AppendFormat("<tr class='{0}'><th>{1}", this.gvCustomers.HeaderStyle.CssClass, e.Row.Cells[0].Text);
            //e.Row.Cells[0].Text = sbNewHeader.ToString();
        }
    }
