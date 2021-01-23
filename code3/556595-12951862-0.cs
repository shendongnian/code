        try{
                HttpContext context = HttpContext.Current;
                context.Response.Clear();
                //dts.WriteXml(Filename, System.Data.XmlWriteMode.IgnoreSchema);
                context.Response.Write("<?xml version=\"1.0\" standalone=\"yes\"?>");
                dts.WriteXml(context.Response.OutputStream, System.Data.XmlWriteMode.IgnoreSchema);
                context.Response.ContentType = "text/xml";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + Filename + ".xml");
                context.Response.End();
        }
