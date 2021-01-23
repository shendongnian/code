    public static class GraphApiRequestProcessor
    {
        public static string GetNewAccessToken( CancellationToken cancellationToken )
        {
            const string tokenUrlPattern = @"https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials";
	        string tokenUrl = string.Format( tokenUrlPattern, Settings.FacebookAppId, Settings.FacebookAppSecret );
            using( var client = new WebClient() )
            {
				// allows cancellation while executing request
	            using( cancellationToken.Register( client.CancelAsync ) )
	            {
					using( var data = client.OpenRead( tokenUrl ) )
					{
						using( var reader = new StreamReader( data ) )
						{
							string response = reader.ReadToEnd();
							int index = response.IndexOf( "=", StringComparison.InvariantCultureIgnoreCase );
							string code = response.Substring( index + 1 );
							return code;	            
						}		            
					}
	            }
            }
        }
	}
