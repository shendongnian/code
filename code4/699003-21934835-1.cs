		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			if (DoesUrlNeedBasicAuth() && Request.IsSecureConnection) //force https before we try and use basic authentication
			{
				if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
				{
					_log.Debug("Web service requested by user " + HttpContext.Current.User.Identity.Name);
				}
				else
				{
					_log.Debug("Null user - use basic auth");
					HttpContext ctx = HttpContext.Current;
					bool authenticated = false;
					// look for authorization header
					string authHeader = ctx.Request.Headers["Authorization"];
					if (authHeader != null && authHeader.StartsWith("Basic"))
					{
						// extract credentials from header
						string[] credentials = extractCredentials(authHeader);
						//Lookup credentials (we'll do this in config for now)
						//check local config first
						var localAuthSection = ConfigurationManager.GetSection("apiUsers") as ApiUsersSection;
						authenticated = CheckAuthSectionForCredentials(credentials[0], credentials[1], localAuthSection);
						if (!authenticated)
						{
							//check sub config
							var webAuth = System.Web.Configuration.WebConfigurationManager.GetSection("apiUsers") as ApiUsersSection;
							authenticated = CheckAuthSectionForCredentials(credentials[0], credentials[1], webAuth);
						}
					}
					// emit the authenticate header to trigger client authentication
					if (authenticated == false)
					{
						ctx.Response.StatusCode = 401;
						ctx.Response.AddHeader("WWW-Authenticate","Basic realm=\"localhost\"");
						ctx.Response.Flush();
						ctx.Response.Close();
						return;
					}
				}
			}
			else
			{
				//do nothing
			}
		}
		/// <summary>
		/// Detect if current request requires basic authentication instead of Forms Authentication.
		/// This is determined in the web.config files for folders or pages where forms authentication is denied.
		/// </summary>
		public bool DoesUrlNeedBasicAuth()
		{
			HttpContext context = HttpContext.Current;
			string path = context.Request.AppRelativeCurrentExecutionFilePath;
			if (context.SkipAuthorization) return false;
			//if path is marked for basic auth, force it
			
			if (context.Request.Path.StartsWith(Request.ApplicationPath + "/integration", true, CultureInfo.CurrentCulture)) return true; //force basic
			//if no principal access was granted force basic auth
			//if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(path, context.User, context.Request.RequestType)) return true;
			return false;
		}
		private string[] extractCredentials(string authHeader)
		{
			// strip out the "basic"
			string encodedUserPass = authHeader.Substring(6).Trim();
			// that's the right encoding
			Encoding encoding = Encoding.GetEncoding("iso-8859-1");
			string userPass = encoding.GetString(Convert.FromBase64String(encodedUserPass));
			int separator = userPass.IndexOf(':');
			string[] credentials = new string[2];
			credentials[0] = userPass.Substring(0, separator);
			credentials[1] = userPass.Substring(separator + 1);
			return credentials;
		}
		/// <summary>
		/// Checks whether the given basic authentication details can be granted access. Assigns a GenericPrincipal to the context if true.
		/// </summary>
		private bool CheckAuthSectionForCredentials(string username, string password, ApiUsersSection section)
		{
			if (section == null) return false;
			foreach (ApiUserElement user in section.Users)
			{
				if (user.UserName == username && user.Password == password)
				{
					Context.User = new GenericPrincipal(new GenericIdentity(user.Name, "Basic"), user.Roles.Split(','));
					return true;
				}
			}
			return false;
		}
