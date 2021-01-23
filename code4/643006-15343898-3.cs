    var handler = new HttpClientHandler
    {
         UseDefaultCredentials = true,
         ServerCertificateCustomValidationCallback = (sender, cert, chain, error) =>
         {
              /// Access cert object.
              return true;
         }
     };
     using (HttpClient client = new HttpClient(handler))
     {
         using (HttpResponseMessage response = await client.GetAsync("https://mail.google.com"))
         {
              using (HttpContent content = response.Content)
              {
              }
          }
     }
