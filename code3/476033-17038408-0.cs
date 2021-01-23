    if (Response.IsClientConnected)
     {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.TransmitFile(Server.MapPath(@"yourpath" + fileName));
        Response.Flush();
        Response.Close();
      }
