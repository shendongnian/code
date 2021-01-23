    class CookieAwareWebClient : WebClient
    {
        private CookieContainer cookie;
        public CookieContainer Cookie { get { return cookie; } }
        public CookieAwareWebClient() {
            cookie = new CookieContainer();
        }
        public CookieAwareWebClient(CookieContainer givenContainer) {
            cookie = givenContainer;
        }
    }
