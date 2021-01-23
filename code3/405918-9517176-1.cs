        /// <summary>
        /// SQL Server database name of the currently selected project.
        /// This name is merged into the connection string in EventConnectionString.
        /// </summary>
        public static string ProjectName
        {
            get
            {
                String _ProjectName = null;
                // See if we have it already
                if (HttpContext.Current.Items["ProjectName"] != null)
                {
                    _ProjectName = (String)HttpContext.Current.Items["ProjectName"];
                }
                // Only have to do this once in each request
                if (String.IsNullOrEmpty(_ProjectName))
                {
                    // Do we have it in the authentication ticket?
                    if (HttpContext.Current.User != null)
                    {
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            if (HttpContext.Current.User.Identity is FormsIdentity)
                            {
                                FormsIdentity identity = (FormsIdentity)HttpContext.Current.User.Identity;
                                FormsAuthenticationTicket ticket = identity.Ticket;
                                _ProjectName = ticket.UserData;
                            }
                        }
                    }
                    // Do we have it in the session (user not logged in yet)
                    if (String.IsNullOrEmpty(_ProjectName))
                    {
                        if (HttpContext.Current.Session != null)
                        {
                            _ProjectName = (string)HttpContext.Current.Session["ProjectName"];
                        }
                    }
                    // Default to the test project
                    if (String.IsNullOrEmpty(_ProjectName))
                    {
                        _ProjectName = "Test_Project";
                    }
                    // Place it in current items so we do not have to figure it out again
                    HttpContext.Current.Items["ProjectName"] = _ProjectName;
                }
                return _ProjectName;
            }
            set 
            {
                HttpContext.Current.Items["ProjectName"] = value;
                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session["ProjectName"] = value;
                }
            }
        }
