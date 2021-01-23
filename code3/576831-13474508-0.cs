    using System.Data;
    using YourNamespace.StoredProcedureNameTableAdapter;
    int someID = int.Parse(this.ReportParameters["ParameterID"].Value.ToString());
    StoredProcedureNameTableAdapter adapter = new StoredProcedureNameTableAdapter();
    DataSetFile.StoredProcedureNameDataTable data = adapter.GetData(someID); //DataSetFile is DataSetFile.xsd and GetData is method name you defined on DataSetFile.xsd creation
    ((Telerik.Reporting.Processing.Report)sender).DataSource = data.AsDataView();
