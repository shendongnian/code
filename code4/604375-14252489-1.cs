            [WebMethod]
            public static void RemoveFile(string fileName)
            {
                List<HttpPostedFile> files = (List<HttpPostedFile>)HttpContext.Current.Session["Files"];
                files.RemoveAll(f => f.FileName.ToLower().EndsWith(fileName.ToLower()));
    
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/Employee/uploads/" + fileName)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Employee/uploads/" + fileName));
                }
            }
