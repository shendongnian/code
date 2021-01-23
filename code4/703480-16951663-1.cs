            // Redirect base path to signin.
            if (context.Request.Path.EndsWith("/"))
            {
                context.Response.RedirectPermanent("signin.ashx");
            }
            // This is reached when the root document is passed. Return HTML
            // using index.html as a template.
            if (context.Request.Path.EndsWith("/signin.ashx"))
            {
