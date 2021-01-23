    public ActionResult ViewCertificate(string fileName)
        {
            try
            {
                var fileStream = System.IO.File.OpenRead(Server.MapPath("~/Certificates/" + fileName));
                return File(fileStream , "application/pdf", fileName);
            }
            catch
            {
                throw new HttpException(404, "Certificate does not found " + fileName);
            }
        }
