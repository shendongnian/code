    [WebMethod(EnableSession = true, 
        Description = "Method for deleting files uploaded by customers")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public Boolean deleteCustFiles(string cNum, string year, string fileName)
    {
        try
        {
            if (String.IsNullOrEmpty(cNum) || String.IsNullOrEmpty(year) ||
                String.IsNullOrEmpty(fileName))
                throw new Exception();
            string path = 
                Server.MapPath(@"~\docs\custFiles\" + year + @"\" + cNum + 
                    @"\" + fileName);
            File.Delete(path);
        }
        catch (System.Security.SecurityException e)
        {
            throw new Exception("Unauthorized attempt to delete file");
        }
        catch
        {
            throw new Exception("Unable to delete file");
        }
        
        return true;
    }
