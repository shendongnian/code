    public class MyServer
        {
            /// <summary>
            /// specify the exposed remote object URI.
            /// </summary>
            private const string REMOTE_OBJECT_URI = "MyService.uri";
    
            /// <summary>
            /// Register the server onto the card.
            /// </summary>
            /// <returns></returns>
            public static int Main()
            {
                // Register the channel the server will be listening to.
                ChannelServices.RegisterChannel(new APDUServerChannel());
    
                // Register this application as a server            
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyService), REMOTE_OBJECT_URI, WellKnownObjectMode.Singleton);
    
                return 0;
            }
        }
