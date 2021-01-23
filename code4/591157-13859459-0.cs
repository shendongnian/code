    string pdfPath = MapPath("mypdf.pdf");
    Response.ContentType = "Application/pdf";
    Response.AppendHeader("content-disposition",
            "attachment; filename=" + pdfPath );
    Response.TransmitFile(pdfPath);
    Response.End();
