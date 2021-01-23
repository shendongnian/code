    Stream objStream;
    StreamReader objSR;
    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
    
    string str = "http://domaninname.com/YourPage.aspx?name=" + "abc";
    HttpWebRequest wrquest = (HttpWebRequest)WebRequest.Create(str);
    HttpWebResponse getresponse = null;
    getresponse = (HttpWebResponse)wrquest.GetResponse();
    
    objStream = getresponse.GetResponseStream();
    objSR = new StreamReader(objStream, encode, true);
    string strResponse = objSR.ReadToEnd();
    Response.Write(strResponse);
