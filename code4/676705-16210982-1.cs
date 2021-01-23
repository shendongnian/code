    Stream st = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "attachment;filename=\"xxx.pdf\"");
    st.CopyStream(Response.OutputStream);
    Response.Output.Flush();
    Response.End();
