    protected void MasterTableView_DataBinding(object sender, EventArgs e)  <- Pay Attention Here
    {
        GridBoundColumn TotalPrice = grdCustomers.MasterTableView.DetailTables[0].GetColumnSafe("TotalPrice") as GridBoundColumn;
        TotalPrice.FooterAggregateFormatString = "<span class=\"AggregateTitleColor\">Sum : </span>" + "{0:#,0 ;#,0- }";
        TotalPrice.FooterStyle.ForeColor = ColorTranslator.FromHtml("blue");
    }
