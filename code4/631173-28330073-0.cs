      public class HttpStatusCodeAdditions
        {
            public const int UnprocessableEntityCode = 422;
            public static HttpStatusCodeAdditions UnprocessableEntity = new HttpStatusCodeAdditions(UnprocessableEntityCode);
    
            private HttpStatusCodeAdditions(int code)
            {
                Code = code;
            }
            public int Code { get; private set; }
    
            public static implicit operator HttpStatusCode(HttpStatusCodeAdditions addition)
            {
                return (HttpStatusCode)addition.Code;
            }
        }
