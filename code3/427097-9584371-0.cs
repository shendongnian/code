    var directory = "/Content/Images/Uploads/" + employee.SSN;
    var path = String.Empty;
    if(!Directory.Exists(Server.MapPath(directory)))
    {
        Directory.CreateDirectory(Server.MapPath(directory));
    }
    foreach(var file in files)
    {
        if(null != file && file.ContentLength > 0)
        {
            path = Path.Combine(directory + "/", Path.GetFileName(file.FileName));
            file.SaveAs(Server.MapPath(path));
            employee.AttachedInformation.Add(path);
        }
    }
