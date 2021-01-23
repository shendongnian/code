    foreach (System.IO.FileInfo fi in di.GetFiles())
    {
         try{
               string ext = "";
               if (fi.Extension.Length > 1)
               {
                     ext = fi.Extension.Substring(1).ToLower();
               }
    
                Response.Write("\t<li class=\"file ext_" + ext + "\"><a href=\"#\" rel=\"" + drive + fi.Name + "\">" + fi.Name + "</a></li>\n");
            }
            catch(..) {
              //handle here exception raised during SINGLE file parsing
            }
    }// Arquiv
