    //Create Connection.
    Entities db = new Entities();
    
    //Get the Data Using the query supplied (Where Entities.SomeObject is the Entity to retrieve data).
    IQueryable<Object> data = db.CreateQuery<Object>("SELECT VALUE c FROM Entities.SomeObject AS c WHERE c.SomeValue> 0");
    //Reset Control. Doesn't Usually work if this is skipped for some reason.
    ReportViewer1.Reset();
    //Load Report Definition.
    // From File.
    ReportViewer1.LocalReport.ReportPath = "C:\\Report.rdlc";
    //Load Report Data.
    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", data));
    //Refresh Control.
    ReportViewer1.LocalReport.Refresh();
