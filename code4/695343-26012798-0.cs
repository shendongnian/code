    string absolutePath = "~/your path";
    try {
    	//copy to MemoryStream
    	MemoryStream ms = new MemoryStream();
    	using (FileStream fs = File.OpenRead(Server.MapPath(absolutePath))) 
    	{ 
       		fs.CopyTo(ms); 
    	}
    	
    	//Delete file
    	if(File.Exists(Server.MapPath(absolutePath)))
    	   File.Delete(Server.MapPath(absolutePath))
    	
    	//Download file
    	Response.Clear()
    	Response.ContentType = "image/jpg";
    	Response.AddHeader("Content-Disposition", "attachment;filename=\"" + absolutePath + "\"");
    	Response.BinaryWrite(ms.ToArray())
    }
    catch {}
    
    Response.End();
