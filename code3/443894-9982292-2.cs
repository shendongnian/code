     private string ControlToString(string controlPath, object model)
            {
                //CshtmlView control = new CshtmlView(controlPath);
                RazorView control = new RazorView(this.ControllerContext, controlPath, null, false, null);
    
                this.ViewData.Model = model;
    
                using (System.Web.UI.HtmlTextWriter writer = new System.Web.UI.HtmlTextWriter(new System.IO.StringWriter()))
                {
                    control.Render(new ViewContext(this.ControllerContext, control, this.ViewData, this.TempData, writer), writer);
    
                    string value = ((System.IO.StringWriter)writer.InnerWriter).ToString();
                    return value;
                }
            }
