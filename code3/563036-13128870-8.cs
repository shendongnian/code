    public class FooController : ApiController { 
        
        public string Put(int id, JObject data)
    }
    public class FooRPCController : ApiController { 
        [HttpPut]
        public bool Lock(int id)
        [HttpPut]
        public bool Unlock(int id)
    }
