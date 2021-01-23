    [DefaultProperty("Text")]  
    [ToolboxData("<{0}:TypeScript runat=server></{0}:TypeScript>")]  
    public class TypeScript : WebControl  
    {  
        public string Text { get; set; }
        protected override void RenderContents(HtmlTextWriter output)  
        {  
            output.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");  
            if (!string.IsNullOrEmpty(this.ID))
            {
                output.AddAttribute(HtmlTextWriterAttribute.Id, this.ID);  
            }
            output.RenderBeginTag("script");
            output.Write(CompileToJavaScript(Text));
            output.RenderEndTag();
        }
        private string CompileToJavaScript(string typeScript)
        {
            // TODO: Call tsc with the code, and return the result.
        }
    } 
