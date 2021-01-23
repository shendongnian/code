    WebRequest objRequest = System.Net.HttpWebRequest.Create(url);
    objResponse = objRequest.GetResponse();
    byte[] buffer = new byte[32768];
    using (Stream input = objResponse.GetResponseStream())
    {
    using (FileStream output = new FileStream ("test.doc",
    FileMode.CreateNew))
    {
    int bytesRead;
     
    while ( (bytesRead=input.Read (buffer, 0, buffer.Length)) > 0)
    {
    output.Write(buffer, 0, bytesRead);
    }
    }
    } 
