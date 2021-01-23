			public static StreamReader GetWebRequestStream(
				 string url,
				 string contentType,
				 bool useDefaultCredentials,
				 IPrincipal user)
			{
				
				var impersonationContext = ((WindowsIdentity)user.Identity).Impersonate();            
				var request = WebRequest.Create(url);
				try
				{
					request.ContentType = contentType;
					//request.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
					//request.UseDefaultCredentials = useDefaultCredentials;            
					//IWebProxy p = new WebProxy();
					//request.Proxy = p.
					request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
					request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
					var response = (HttpWebResponse)request.GetResponse();
					return new StreamReader(response.GetResponseStream());
				}
				catch (Exception e)
				{
					impersonationContext.Undo();
					throw e;
				}
				finally
				{
					impersonationContext.Undo();
				}
			}
