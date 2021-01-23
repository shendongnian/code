    using System;
    using System.Data;
    using System.Configuration;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.IO;
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            string filePath = Server.MapPath(Request.QueryString["ax-file-path"]);
            string allowExtstr	= Request.QueryString["ax-allow-ext"];
            string[] allowExt 	= allowExtstr.Split('|');
    
    
            if (!System.IO.File.Exists(filePath) && filePath.Length > 0)
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
    
            if (!System.IO.File.Exists(thumbPath) && thumbPath.Length > 0)
            {
                System.IO.Directory.CreateDirectory(thumbPath);
            }
    
            if(Request.Files.Count>0)
            {
    	        for (int i = 0; i < Request.Files.Count; ++i)
    	        {
    		        HttpPostedFile file = Request.Files[i];
                    string fullPath = checkFilename(file.FileName, allowExt, filePath);
    			    file.SaveAs(fullPath);
    			    Response.Write(@"{""name"":"""+System.IO.Path.GetFileName(fullPath)+@""",""size"":""0"",""status"":""uploaded"",""info"":""File/chunk uploaded""}");
    	        }
            }
        }
     
            public string checkFilename(string filename, string[] allowExt, string filePath)
            {	
    	        string[] windowsReserved	= new string[] {"CON", "PRN", "AUX", "NUL","COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                				        "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"};    
    	        string[] badWinChars		= new string[] {"<", ">", ":", @"\", "/", "|", "?", "*"};
    
                for (int i = 0; i < badWinChars.Length; i++)
                {
                    filename.Replace(badWinChars[i], "");        
                }
                string fileExt		= System.IO.Path.GetExtension(filename);
                fileExt = fileExt.Replace(".", "");
                string fileBase		= System.IO.Path.GetFileName(filename);
        
                //check if legal windows file name
                if(Array.IndexOf(windowsReserved, fileBase)>=0)
    	        {
                    Response.Write(@"{""name"":"""+fileBase+@""",""size"":""0"",""status"":""error"",""info"":""File name not allowed. Windows reserverd.""}");
    		        return "error";
    	        }
    	
                //check if is allowed extension
                if (Array.IndexOf(allowExt, fileExt) < 0 && allowExt.Length > 0)
                {
                    if (allowExt.Length != 1 || !String.Equals(allowExt[0], ""))
                    {
                        Response.Write(@"{""name"":""" + fileBase + @""",""size"":" + allowExt[0] + @",""status"":""error"",""info"":""Extension " + fileExt + @" not allowed.""}");
                        return "error";
                    }
                }
        
    	        string fullPath = filePath+fileBase;
                int c=0;
    	        while(System.IO.File.Exists(fullPath))
    	        {
    		        c++;
    		        fileBase= fileBase+"("+c.ToString()+")."+fileExt;
    		        fullPath 	= filePath+fileBase;
    	        }
    	        return fullPath;
            }
    }
