    public sealed class HttpGetTest : ITest {
        private readonly string m_url;
    
        public HttpGetTest( string url ) {
            m_url = url;        
        }
    
        public void ITest.Execute() {
            using( var m_webClient = new WebClient())
            {
                using( Stream stream = m_webClient.OpenRead( m_url ) ) 
                {
    
                }
            }
        }
    }
