    string json = "{\"add\":{\"doc\":{"
	  + "\"UUID\":\"d2a174e4-81d6-487f-b68d-392be5d3d47a\","
      + "\"Extension\":\".AVI\","
      + "\"VideoFileName\":\"Clip 1.avi\"}},";
	  + "\"commit\":{}}";
    string uri = "http://localhost:8080/solr/collection/update";
      
    WebRequest request = WebRequest.Create(uri);
    request.ContentType = "application/json";
    request.Method = "POST";
    byte[] bytes = Encoding.ASCII.GetBytes(json);
    Stream stream = null;
    
    try {
      request.ContentLength = bytes.Length;
      stream = request.GetRequestStream();
      stream.Write(bytes, 0, bytes.Length);
    }
    catch {
      return;
    }
    finally {
      if (stream != null) {
        stream.Close();
      }
    }
    System.Net.WebResponse response = request.GetResponse();
    if (response == null) {
      return;
    }
