            this.PreRequestFilters.Add((req, resp) =>
            {
                IAuthSession session = req.GetSession();
                if (session.UserName == null)
                {
                    session.UserName = ((HttpRequestWrapper)req.OriginalRequest).LogonUserIdentity.Name;
                    // Add permissions & roles here - IUserAuthRepository, ICacheClient, etc.
                    req.SaveSession(session);
                }
            });
