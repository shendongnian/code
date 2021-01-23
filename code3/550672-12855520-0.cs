     using (HttpClient client = new HttpClient())
     {
          client.DefaultRequestHeaders.ExpectContinue = false;
          
          ....code!
     }
