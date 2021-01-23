         try
         {
            var request = HttpWebRequest.Create(url);
            request.Timeout = 3000;
            var response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
               //do stuff
            }
         }
         catch (Exception exception)
         {
            exception.ToLog();
         }
