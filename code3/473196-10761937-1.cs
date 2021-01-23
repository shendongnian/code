        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // we open one NH session for every web request, 
            var nhsession = SessionFactory.OpenSession();
            // and bind it to the SessionFactory current session
            CurrentSessionContext.Bind(nhsession);
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            // close/unbind at EndRequest
            if (SessionFactory != null)
            {
                var nhsession = CurrentSessionContext.Unbind(SessionFactory);
                nhsession.Dispose();
            }
        }
