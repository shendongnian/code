        WebResponse myWebResponse = myWebRequest.GetResponse(); 
      	// Obtain a 'Stream' object associated with the response object.
    	Stream ReceiveStream = myWebResponse.GetResponseStream();
            	
    	Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
    
         // Pipe the stream to a higher level stream reader with the required encoding format. 
    	 StreamReader readStream = new StreamReader( ReceiveStream, encode );
    	 Console.WriteLine("\nResponse stream received");
    	 Char[] read = new Char[256];
    
         // Read 256 charcters at a time.     
    	 int count = readStream.Read( read, 0, 256 );
         Console.WriteLine("HTML...\r\n");
    
    	 if (count > 0) 
    	 {
               Console.Write("Success Reading");
         }
    
