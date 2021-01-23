    RunOperationAsUser(() => {
        GridViewRow rw = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        LinkButton lnkTxtFile = (LinkButton)rw.FindControl("lnkTxtFile");
        string strFilename = lnkTxtFile.Text.Replace("/","\\");
        System.IO.FileInfo targetFile = new System.IO.FileInfo(strFilename);
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + targetFile.Name);
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(targetFile.FullName);
        //HttpContext.Current.ApplicationInstance.CompleteRequest();
        Response.End();
    }, userName, domain, password)
    
