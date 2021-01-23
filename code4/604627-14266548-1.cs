    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod]
        public AjaxControlToolkit.Slide[] GetSlides(string contextKey)
        {
           
            string[] imagenames = System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/" + contextKey ));
            AjaxControlToolkit.Slide[] photos = new AjaxControlToolkit.Slide[imagenames.Length];
            for (int i = 0; i < imagenames.Length; i++)
            {
                string[] file = imagenames[i].Split('\\');
                photos[i] = new AjaxControlToolkit.Slide(contextKey + "/" + file[file.Length - 1], file[file.Length - 1], "");
            }
            return photos;
           
        }
      }
