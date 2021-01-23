		void Application_Error( object sender, EventArgs e )
		{
			Boolean errorRedirect = false;
			Boolean redirect404 = false;
			try
			{
				var exception = Server.GetLastError();
				var httpException = exception as HttpException;
				Response.Clear();
				Server.ClearError();
				var routeData = new RouteData();
				routeData.Values[ "controller" ] = "Errors";
				routeData.Values[ "action" ] = "General";
				routeData.Values[ "exception" ] = exception;
				Response.StatusCode = 500;
				if ( httpException != null )
				{
					Response.StatusCode = httpException.GetHttpCode();
					switch ( Response.StatusCode )
					{
						case 403:
							redirect404 = true;
							break;
						case 404:
							redirect404 = true;
							break;
						default:
    errorRedirect = true;
							//todo: log errors in your log file here
							break;
					}
				}
			}
			catch ( Exception ex )
			{
				errorRedirect = true;
			}
			if ( redirect404 )
			{
				//redirect to 404 page
				Response.Redirect( "~/404.htm" );
			}
			else if ( errorRedirect )
			{
				//redirect to error page
				Response.Redirect( "~/error.htm" );
			}
		}
