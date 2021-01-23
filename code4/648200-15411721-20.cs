    string FileName = "Hello.doc";
    string Filename = strFileName.Substring(0, FileName.LastIndexOf("."));                      
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
    Response.TransmitFile(Server.MapPath("~/Folder_Name/" + FileName));
    Response.End();
