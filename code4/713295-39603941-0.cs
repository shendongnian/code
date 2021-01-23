     var mockactioncontext = new HttpActionContext
                {
                    ControllerContext = new HttpControllerContext
                    {
                        Request = new HttpRequestMessage()
                    },
                    ActionArguments = { { "employeeid", "null" } }
                };
    
                mockactioncontext.ControllerContext.Configuration = new HttpConfiguration();
                mockactioncontext.ControllerContext.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
                
                var filter = new <youractionattributefilterclass>();
                filter.OnActionExecuting(mockactioncontext);
                Assert.IsTrue(mockactioncontext.Response.StatusCode == HttpStatusCode.BadRequest);
