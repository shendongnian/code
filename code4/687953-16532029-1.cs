    public class Response<T>
    {
      public T Data {get;set;}
      public List<Error> Errors {get;set;}
    }
    public static Response<T> GetResponse<T>(this IRestResponse restResponse)
    {
            var response = new Response<T>();
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.Data = JsonConvert.DeserilizeObject<T>(restResponse.Data)
            }
            
            response.Errors =JsonConvert.DeserilizeObject<List<Error>>(restResponse.Error)
    
            return response;
    }
