     public static void SetBasicAuthentication(this HttpClient client, string userName, string password);
        //
        // Summary:
        //     Sets a basic authentication header.
        //
        // Parameters:
        //   request:
        //     The HTTP request message.
        //
        //   userName:
        //     Name of the user.
        //
        //   password:
        //     The password.
        public static void SetBasicAuthentication(this HttpRequestMessage request, string userName, string password);
        //
        // Summary:
        //     Sets a basic authentication header for RFC6749 client authentication.
        //
        // Parameters:
        //   client:
        //     The client.
        //
        //   userName:
        //     Name of the user.
        //
        //   password:
        //     The password.
        public static void SetBasicAuthenticationOAuth(this HttpClient client, string userName, string password);
        //
        // Summary:
        //     Sets a basic authentication header for RFC6749 client authentication.
        //
        // Parameters:
        //   request:
        //     The HTTP request message.
        //
        //   userName:
        //     Name of the user.
        //
        //   password:
        //     The password.
        public static void SetBasicAuthenticationOAuth(this HttpRequestMessage request, string userName, string password);
        //
        // Summary:
        //     Sets an authorization header with a bearer token.
        //
        // Parameters:
        //   client:
        //     The client.
        //
        //   token:
        //     The token.
        public static void SetBearerToken(this HttpClient client, string token);
        //
        // Summary:
        //     Sets an authorization header with a bearer token.
        //
        // Parameters:
        //   request:
        //     The HTTP request message.
        //
        //   token:
        //     The token.
        public static void SetBearerToken(this HttpRequestMessage request, string token);
        //
        // Summary:
        //     Sets an authorization header with a given scheme and value.
        //
        // Parameters:
        //   client:
        //     The client.
        //
        //   scheme:
        //     The scheme.
        //
        //   token:
        //     The token.
        public static void SetToken(this HttpClient client, string scheme, string token);
        //
        // Summary:
        //     Sets an authorization header with a given scheme and value.
        //
        // Parameters:
        //   request:
        //     The HTTP request message.
        //
        //   scheme:
        //     The scheme.
        //
        //   token:
        //     The token.
        public static void SetToken(this HttpRequestMessage request, string scheme, string token);
