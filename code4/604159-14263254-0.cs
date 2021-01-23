    public static class RazorFormatExtensions
    {
        public static RazorFormat AddPage(this RazorFormat razor, 
            string pageTemplate, string pageName = "Page")
        {
            razor.AddPage(
                new ViewPageRef(razor, "/path/to/tpl", pageName, pageTemplate)
                {
                    Service = razor.TemplateService
                });
            razor.TemplateService.RegisterPage("/path/to/tpl", pageName);
            razor.TemplateProvider.CompileQueuedPages();
            return razor;
        }
        public static string RenderToHtml<T>(this RazorFormat razor, 
            T model, string pageName = "Page")
        {
            var template = razor.ExecuteTemplate(model, pageName, null);
            return template.Result;
        }
    }
