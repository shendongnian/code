        public HttpResponseMessage Get(string id) {
        {
            var value = new iOSDevice();
            var response = Request.CreateResponse();
            response.Content = new ObjectContent(typeof(iOSDevice), value, new iOSDeviceXmlFormatter());
            //set headers on the "response"
            return response;
        }
