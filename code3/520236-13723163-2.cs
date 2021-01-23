    var repGen = new YourReport
                                 {
                                     Parameter1 = someValue1,
                                     Parameter2 = someValue2,
                                     Parameter3 = someValue3,
                                     SubReportParameter1 = someValue4,
                                     SubReportParameter2 = someValue5,
                                     EntityList = someList1,
                                     SubReportEntityList = someList2
                                 };
    var repExp = repGen.GenerateReport(format, out mimeType, out fileName);
    Response.Buffer = true;
    Response.Clear();
    Response.ContentType = mimeType;
    Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
    Response.BinaryWrite(repExp);
    Response.Flush();
