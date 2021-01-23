    public class CookieJarException : Exception
        {
            public CookieJar Jar {get; private set;}
        
            public CookieJarException(CookieJar a)
            {
                Jar = a;
            }
        
        }
