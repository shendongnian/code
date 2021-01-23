    public class RestServiceImpl : IRestServiceImpl
    {
        public JSONResponse JSONData(string id)
        {
            return new JSONResponse { Response = "You requested product " + id };
        }
    }
    
    public class JSONResponse
    {
        public string Response { get; set; }
    }
