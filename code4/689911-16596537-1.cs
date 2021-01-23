    [HttpGet]
        public HttpResponseMessage Capture(int width)
        { 
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StreamContent(File.OpenRead(@"C:\Images\Car.jpg"));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
        }
