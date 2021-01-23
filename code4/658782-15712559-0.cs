        public static string JsonWithAuth( string url, string data )
        {
            var bytes = Encoding.Default.GetBytes( data );
            using ( var client = new WebClientEx() )
            {
                var values = new NameValueCollection
                {
                    { "username", "myUsername" },
                    { "password", "myPassword" },
                };
                // Authenticate
                client.UploadValues( "http://192.168.7.9/main/signin", values );
                // Post data
                var response = client.UploadData( url, "POST", bytes );
                return Encoding.Default.GetString( response );
            }
        }
