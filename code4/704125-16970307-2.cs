        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            var app = ((HttpApplication)sender);
            var ctx = app.Context;
            if (app.Context.Handler != null && app.Context.Handler is Page)
            { // Register PreRender handler only on aspx pages.
                Page page = (Page)HttpContext.Current.Handler;
            }
        }
