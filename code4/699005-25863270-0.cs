      /// <summary>
      /// Authenticates the application request.
      /// Basic authentication is used for requests that start with "/HealthCheck".
      /// IIS Authentication settings for the HealthCheck folder:
      /// - Windows Authentication: disabled.
      /// - Basic Authentication: enabled.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">A <see cref="System.EventArgs"/> that contains the event data.</param>
      protected void Application_AuthenticateRequest(object sender, EventArgs e)
      {
         var application = (HttpApplication)sender;
         if (application.Context.Request.Path.StartsWith("/HealthCheck", StringComparison.OrdinalIgnoreCase))
         {
            if (HttpContext.Current.User == null)
            {
               var context = HttpContext.Current;
               context.Response.SuppressFormsAuthenticationRedirect = true;
            }
         }
      }
