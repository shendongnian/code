    SearchResultCollection results = searcher.FindAll();
    
                List<string> inactiveComputerNames = new List<string>();
    
                object threadLock = new object();
    
                Parallel.ForEach( results.OfType<SearchResult>(), result =>
                {
                    if( result.GetDirectoryEntry().Name.StartsWith( "CN=" ) )
                    {
                        string computerName = result.GetDirectoryEntry().Name.Remove( 0, "CN=".Length );
    
                        try
                        {
                            Dns.GetHostAddresses( computerName );
                        }
    
                        catch( SocketException )
                        {
                            lock( threadLock )
                            {
                                inactiveComputerNames.Add( computerName );
                            }
                        }
                    }
                }
                );
