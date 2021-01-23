    if (Request.QueryString["ID"] != null)  
    {
        //find file by its ID
                ...
        Response.AddHeader("Content-disposition", "attachment; filename=" + fileName));
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(fullFileName);
        Response.End();
    }
