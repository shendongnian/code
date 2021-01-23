    var request = WebRequest.Create("http://www.conquerclub.com/login.php");
    request.Method = "POST";
    var parameters = new Dictionary<string, string> { 
        { "username", "testuser1" }, 
        { "password", "testing" }, 
        { "redirect", "game.php?game=13025037" }, 
        { "direct", "63###www.conquerclub.com###" }, 
        { "protocol", "HTTP" }, 
        { "submit", "Login" } };
    var content = string.Join( "&", ( from p in parameters select p.Key + "=" + HttpUtility.UrlEncode( p.Value) ).ToArray() ); ;
    byte[] bytes = new byte[content.Length * sizeof(char)];
    System.Buffer.BlockCopy(content.ToCharArray(), 0, bytes, 0, bytes.Length);
    request.ContentLength = bytes.Length;
    request.ContentType = "application/x-www-form-urlencoded";
    Stream dataStream = request.GetRequestStream();
    dataStream.Write( bytes, 0, bytes.Length );
    dataStream.Close();
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    StreamReader reader = new StreamReader(response.GetResponseStream());
    string result = reader.ReadToEnd();
