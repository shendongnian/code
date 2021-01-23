		protected override void OnError( EventArgs e )
		{
			try
			{
				//todo: log errors in your log files
			}
			catch ( Exception ex ) { }
			//redirect to error page
			Response.Redirect( "~/error.htm" );
		}
