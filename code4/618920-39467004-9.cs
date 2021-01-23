        public static class HttpClientExtentions
        {
            public static AuthenticationHeaderValue ToAuthHeaderValue(this string username, string password)
            {
                return new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(
                System.Text.Encoding.ASCII.GetBytes(
                    $"{username}:{password}")));
            }
        }
