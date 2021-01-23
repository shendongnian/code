    public class Expander { 
        public ITemplate ContentTemplate {get ;set;}
        public HtmlGenericControl ContentTemplateContainer{get;set;}
        protected override void OnInit(EventArgs e) {
            this.ContentTemplateContainer = new HtmlGenericControl("div");
            if (ContentTemplate != null) {
                ContentTemplate.InstantiateIn(container);
            }
            plcContent.Controls.Add(container);
           
        }
    }
