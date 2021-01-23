        Response.ContentType = "application/xml";
        Response.AddHeader("Content-Disposition", String.Format("inline; filename={0}.xml", Path.GetFileName(Path)));
        Response.WriteFile(path); // 
        Response.Flush();
        // Response.Close(); // end should do this anyway so optional
        Response.End(); // end forces the server to send the request immediately. Failing to 
