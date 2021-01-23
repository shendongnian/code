           // String with the body content 
            string postBody = "{\"name\":\"myfoldername\"}";
            ASCIIEncoding encoding = new ASCIIEncoding ();
            byte[] byte1 = encoding.GetBytes (postBody);
            // Set Content type to application/json
            myHttpWebRequest.ContentType = "application/json";
            // Set content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length;
            // Get the request stream and write body bytes to it
            Stream newStream = myHttpWebRequest.GetRequestStream ();
            newStream.Write (byte1, 0, byte1.Length);
