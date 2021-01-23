    namespace YourProject.Helpers
    {
        public static class HtmlHelperExtensions
        {
            public static IDisposable CustomBeginForm(this HtmlHelper helper, string html)
            {
                return new MvcFormExtension(helper, html);
            }
            private class MvcFormExtension : IDisposable
            {
                private HtmlHelper helper;
                private MvcForm form;
                private string html;
                public MvcFormExtension(HtmlHelper helper, string html)
                {
                    this.helper = helper;
                    this.form = this.helper.BeginForm();
                    this.html = html;
                }
                public void Dispose()
                {
                    form.EndForm();
                    helper.ViewContext.Writer.Write(this.html);
                }
            }
        }
    }
