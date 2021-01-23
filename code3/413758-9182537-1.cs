    private void OpenPDF(string downloadAsFilename)
    {
        ReportDocument Rel = new ReportDocument();
        Rel.Load(Server.MapPath("../Reports/Test.rpt"));
        BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=" + downloadAsFilename);
        Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
        Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
        Response.Flush();
        Response.Close(); 
    }
