            var client = new HttpClient("http://localhost:38477/social");
            client.DefaultHeaders.Accept.AddString("application/xml");
            client.DefaultHeaders.ContentType = "application/xml";
            HttpResponseMessage responseMessage = client.Get("twitter_name");
            var deserializedContent = responseMessage.Content.ReadAsDataContract<YourTypeHere>();
