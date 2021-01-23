       using System;
       using System.Web;
       using System.IO;
       using System.Web.Script.Services;
       using System.Web.Services;
       [ScriptService]
        public partial class Save_Picture : System.Web.UI.Page
        {
            [WebMethod()]
            public static void UploadPic (string imageData)
            {
                byte[] data = Convert.FromBase64String(imageData);
                // save it in a file or database ...
            }
        }
