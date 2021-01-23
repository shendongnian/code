		void Application_Error(object sender, EventArgs e )
		{
			Exception ex = Server.GetLastError();
			if ( ex != null )
			{
				if ( ex.GetBaseException() != null )
				{
					ex = ex.GetBaseException();
				}
				if ( Session != null )  // Exception occurred here.
				{
					Session[ "LastException" ] = ex;
				}
				Toolbox.Log( LogLevel.Error, "An Application Error Occurred", ex );
			}
		}
