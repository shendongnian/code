    private void Report1_NeedDataSource(object sender, EventArgs e)
    {
        Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;
        this.Report1DS.Parameters[0].Value = your value to be passed to data source..;
        // Similarly you can add more values of parameters.
        rpt.DataSource = Report1DS;
    }
