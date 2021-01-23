        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetAllMessages()
        {
            try
            {
                //Load Data Into List
                var mm = new MessageManager();
                List<Message> msgs = mm.GetAllMessages();
                //Convert List Into JSON
                var jsonmsgs = JsonConvert.SerializeObject(msgs);
                //Create a HTTP response - Set to OK
                var res = Request.CreateResponse(HttpStatusCode.OK);
                //Set the content of the response to be JSON Format
                res.Content = new StringContent(jsonmsgs, System.Text.Encoding.UTF8, "application/json");
                
                //Return the Response
                return res;
            }
            catch (Exception exc)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc);
            }
        }
