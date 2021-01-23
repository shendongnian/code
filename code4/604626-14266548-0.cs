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
     in slideshow extender
     <asp:SlideShowExtender ID="SlideShowExtender1" TargetControlID="Image1"     SlideShowServiceMethod="GetSlides" SlideShowServicePath="~/WebService1.asmx" Loop="true" runat="server"  UseContextKey="true" 
        AutoPlay="True" BehaviorID="b1" >        
    </asp:SlideShowExtender>
     finally in page_load
     if (Page.IsPostBack)
            {
                SlideShowExtender1.ContextKey = DropDownList1.SelectedValue;
                
            }
