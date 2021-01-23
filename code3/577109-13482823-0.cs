    HttpWebRequest request = (HttpWebRequest)WebRequest.Create (args[0]);
    
                // Set some reasonable limits on resources used by this request
                request.MaximumAutomaticRedirections = 4;
                request.MaximumResponseHeadersLength = 4;
                // Set credentials to use for this request.
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
    
                Console.WriteLine ("Content length is {0}", response.ContentLength);
                Console.WriteLine ("Content type is {0}", response.ContentType);
    
                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream ();
    
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);
    
                Console.WriteLine ("Response stream received.");
                Console.WriteLine (readStream.ReadToEnd ());
                response.Close ();
                readStream.Close ();
