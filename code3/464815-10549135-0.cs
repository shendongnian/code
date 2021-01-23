    public void downloadFile(string fileName, string filePath)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", fileName));
            Response.WriteFile(filePath + fileName);
        }
