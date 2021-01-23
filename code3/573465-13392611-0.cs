            string msg;
            msg = "===================================================================================";
            Debug.WriteLine( msg );
            try
                {
                LiveConnectClient liveClient = new LiveConnectClient( App.Session );
                LiveOperationResult operationResult = await liveClient.GetAsync( "me/calendars" );
                dynamic result = operationResult.Result;
                List<object> data = null;
                IDictionary<string, object> calendar = null;
                msg = "Calendar names: ";
                Debug.WriteLine( msg );
                if ( operationResult.Result.ContainsKey( "data" ) )
                    {
                    data = (List<object>)operationResult.Result[ "data" ];
                    for ( int i = 0 ; i < data.Count ; i++ )
                        {
                        calendar = (IDictionary<string, object>)data[ i ];
                        if ( calendar.ContainsKey( "name" ) )
                            {
                            string Name = (string)calendar[ "name" ];
                            string ID   = (string)calendar[ "id" ];
                            msg = string.Format( "Name = {0}, ID = {1}", Name, ID );
                            Debug.WriteLine( msg );
                            }
                        }
                    }
                }
            catch ( LiveConnectException exception )
                {
                Debug.WriteLine( "Error getting calendar info: " + exception.Message );
                }
            msg = "===================================================================================";
            Debug.WriteLine( msg );
