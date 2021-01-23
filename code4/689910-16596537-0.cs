        [HttpGet]
        public HttpResponseMessage Capture(int width)
        { 
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new PushStreamContent((responseStream, httpContent, transportContext) =>
                {
                    using (responseStream)
                    {
                        img.Save(responseStream, ImageFormat.Jpeg);
                    }//closing this important!
                });
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
        }
