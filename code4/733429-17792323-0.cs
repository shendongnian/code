    WebRequest request = WebRequest.Create(url);
    NetworkCredential credential = new NetworkCredential(username, password);
    
    request.Credentials = credential;
    request.PreAuthenticate = true;
    
    WebResponse response = request.GetResponse();
    Stream Answer = response.GetResponseStream();
    
    StreamReader _Answer = new StreamReader(Answer); 
    string content = _Answer.ReadToEnd(); //the string of the whole xml
    response.Close();
