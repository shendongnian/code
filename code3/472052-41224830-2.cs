        [Route("DoSomeAction")]
        [HttpPost]
        public HttpResponseMessage DoSomeAction(int? someProp1 = null, string someOtherProp2 = null, int? minProp = null, int? maxProp = null)
        {
            try
            {
                var filters = new RequestFilters 
                {
                    SomeProp1 = someProp1 ,
                    SomeOtherProp2 = someOtherProp2.TrySplitIntegerList() ,
                    MinProp = minProp, 
                    MaxProp = maxProp
                };
                var result = theService.DoSomeAction(filters);
                return !result.IsError ? Request.CreateResponse(HttpStatusCode.OK, result) : Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            catch (Exception exc)
            {
                Logger.Log(LogLevel.Error, exc, "Failed to DoSomeAction");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError("Failed to DoSomeAction - internal error"));
            }
        }
