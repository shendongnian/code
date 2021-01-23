    [WebMethod]
    public string UploadFile(byte[] f, string fileName, string bcode)
    {
        if (bcode.Length > 0)
        {
            try
            {
                string[] fullname = fileName.Split('.');
                string ext = fullname[1];
                if (ext.ToLower() == "jpg")
                {
                    MemoryStream ms = new MemoryStream(f);
                    FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/bookimages/zip/") + bcode+"."+ext, FileMode.Create);
                    ms.WriteTo(fs);
                    ms.Close();
                    fs.Close();
                    fs.Dispose();
                    
                    
                }
                else
                {
                    return "Invalid File Extention.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        else
        {
            return "Invalid Bookcode";
        }
    }
