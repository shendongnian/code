    public class BeginHtmlScope : IDisposable
        {
            private readonly TemplateInfo templateInfo;
            private readonly string previousHtmlFieldPrefix;
    
            public BeginHtmlScope(TemplateInfo templateInfo, string htmlFieldPrefix)
            {
                this.templateInfo = templateInfo;
    
                previousHtmlFieldPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
            }
    
            public void Dispose()
            {
                templateInfo.HtmlFieldPrefix = previousHtmlFieldPrefix;
                
            }
        }
        public static class MyHtmlExtensions
        {
            public static IDisposable BeginHtmlScope(this HtmlHelper html, string htmlFieldPrefix)
            {
                return new BeginHtmlScope(html.ViewData.TemplateInfo, htmlFieldPrefix);
            }
        }
