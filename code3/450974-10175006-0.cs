            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("content-disposition", "attachment; filename=ym.jpg");
            context.Response.TransmitFile(context.Server.MapPath(@"~/ym.jpg"));
            context.Response.End();
