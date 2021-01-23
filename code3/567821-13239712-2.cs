    public override void ExecuteResult(ControllerContext context)  
    {  
        DateTime dt = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));  
    
        context.HttpContext.Response.Clear();  
    
    	FileStream fs = System.IO.File.OpenRead("path_to_swf_file");  
    	byte[] BannerData = new byte[fs.Length];  
    	fs.Read(BannerData, 0, BannerData.Length);  
    	
    	context.HttpContext.Response.ExpiresAbsolute = dt;  
    	context.HttpContext.Response.CacheControl = "no-cache";  
    	context.HttpContext.Response.AddHeader("Pragma", "no-cache");  
    	context.HttpContext.Response.Charset = "utf-8";  
    	context.HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;  
    	context.HttpContext.Response.Expires = -1;  
    	context.HttpContext.Response.CacheControl = "no-cache, no-store, must-revalidate";  
    	context.HttpContext.Response.ContentType = "application/x-shockwave-flash";  
    	context.HttpContext.Response.AppendHeader("Content-Disposition", "attachment; filename=...");  
    	context.HttpContext.Response.BinaryWrite(BannerData);  
    	
    	fs.Close();  
    
        context.HttpContext.Response.End();  
    } 
