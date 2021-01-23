        private HttpSessionState GetSession(HttpApplication context)
        {
            try
            {
                //On Abadon or Logout this returns "Session state is not available in this context. "
                return context.Session;
            }
            catch (HttpException)
            {
                return null;
            }
        }
