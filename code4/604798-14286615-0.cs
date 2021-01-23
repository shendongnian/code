    private object _lockObj=new object();
    public ReportTable GetReportTable(ReportQuery query)
    {
      lock(_lockObj){
        var table = query.GetNewReportTable();
        return table;
      }
    }
