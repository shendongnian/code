        void application_PreRequestHandlerExecute(object sender, EventArgs e){
            ...
            if (HttpContext.Current.Handler is IRequiresSessionState) {
                if (!context.User.Identity.IsAuthenticated)
                    AuthService.DefaultProvider.AuthenticateUserFromExternalSource();
