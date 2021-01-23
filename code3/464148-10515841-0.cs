    public class FileAccessHandler:IHttpHandler
    {
	    public FileAccessHandler()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
        public bool IsReusable
        {
            get { return false; }
        }
        public void ProcessRequest(HttpContext context)
        {
            String FileName = Path.GetFileName(context.Request.PhysicalPath);
            String AssetName = HttpContext.Current.Request.MapPath(Path.Combine(HttpContext.Current.Request.ApplicationPath, "App_Data/" + FileName));
            if (File.Exists(AssetName))
            {
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(File.ReadAllBytes(AssetName));
                context.Response.End();
            }
        }
    }
