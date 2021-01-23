    using System.Data;
    using YourNamespace.StoredProcedureNameTableAdapter;
    //Keep in mind StoredProcedureName is taken from SP name in your database
    //when you add DataSet.xsd to your solution by default if you don't change anything
    private void ClassName_NeedDataSource(object sender, EventArgs e)
    {
       int someID = int.Parse(this.ReportParameters["ParameterID"].Value.ToString());
       StoredProcedureNameTableAdapter adapter = new StoredProcedureNameTableAdapter();
       DataSetFile.StoredProcedureNameDataTable data = adapter.GetData(someID); //DataSetFile is DataSetFile.xsd and GetData is method name you defined on DataSetFile.xsd creation
       ((Telerik.Reporting.Processing.Report)sender).DataSource = data.AsDataView();
    }
