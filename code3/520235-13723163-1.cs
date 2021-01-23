    public class YourReport: ReportGenerator
    {
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string SubReportParameter1 { get; set; }
        public string SubReportParameter2 { get; set; }
        public List<SomeEntity> EntityList { get; set; }
        public List<SomeOtherEntity> SubReportEntityList { get; set; }
        private readonly CodeBehindClassForAnySubReport _anySubReport;
        public YourReport():base("ReportName", "ReportFileName")
        {
            _anySubReport = new YourReport();
            SetSubReports(_anySubReport);
        }
        public override void SetParamsAndDataSources()
        {
            SetReportParameterValue("Param1NameInReport", Parameter1);
            SetReportParameterValue("Param2NameInReport", Parameter2);
            SetReportParameterValue("Param3NameInReport", Parameter3);
            SetReportParameterValue("SubParam1NameInReport", SubReportParameter1);
            SetReportParameterValue("SubParam2NameInReport", SubReportParameter2);
            base.SetDataSourceValue("DataSourceNameInReport", EntityList);
            _anySubReport.EntityList = this.SubReportEntityList;
            //Call this only when subreport contains any datasource.
            //Parameters for subreports should be chained in the report design
            _anySubReport.SetParamsAndDataSources();
        }
    }
