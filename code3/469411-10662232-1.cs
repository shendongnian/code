    public void SaveFileOnDisk(MemoryStream ms, string FileName)
    {
        try
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);
            string strpath = physicalPath + "\\Images";
            string WorkingDirectory = strpath;
    
            using (var original = Image.FromStream(ms))
    		using (var resized = ResizeWithSameRatio(original, 1024, 768))
    		{
            	resized.Save(WorkingDirectory + "\\" + FileName + ".jpg");
    		}
        }
        catch (Exception ex)
        {
            //lblMsg.Text = "Please try again later.";
        }
    }
