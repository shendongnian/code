    private class CustomRestClient : RestClient
            {
                public CustomRestClient(string baseUrl) : base(baseUrl) { }
    
                private IRestResponse<T> Deserialize<T>(IRestRequest request, IRestResponse raw)
                {
                    request.OnBeforeDeserialization(raw);
                    var restResponse = (IRestResponse<T>)new RestResponse<T>();
                    try
                    {
                        restResponse = ResponseExtensions.toAsyncResponse<T>(raw);
                        restResponse.Request = request;
                        if (restResponse.ErrorException == null)
                        {
    
                            restResponse.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
                        }
                    }
                    catch (Exception ex)
                    {
                        restResponse.ResponseStatus = ResponseStatus.Error;
                        restResponse.ErrorMessage = ex.Message;
                        restResponse.ErrorException = ex;
                    }
                    return restResponse;
                }
    
    
    
                public override IRestResponse<T> Execute<T>(IRestRequest request)
                {
                    return Deserialize<T>(request, Execute(request));
                }
            }
