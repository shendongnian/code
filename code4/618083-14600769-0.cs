        public class ClientResult
        {
            public int a {get;set;}
        }
        public class ClientResult<T> : ClientResult
        {
            public ClientResult(ClientResult cr)
            {
                this.a = cr.a;
            }
        }
        public class Result<T> : Result
        {
            public T details { get; set; }
            public ClientResult<T> ToClientResult<T>()
            {
                var cr = base.ToClientResult();
                return new ClientResult<T>(cr);  
            }
        }
