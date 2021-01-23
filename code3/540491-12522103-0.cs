        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage response;
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customer);
                response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(300));
            }
            return response;
        }
