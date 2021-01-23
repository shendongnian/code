    for(int i = 1; i < 45;i++){
    string url = "http://website.com/list/"+i;
    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
    myRequest.Method = "GET";
    WebResponse myResponse = myRequest.GetResponse();
    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
    string result = sr.ReadToEnd();
    sr.Close();
    myResponse.Close();
    //do something with the result
    }
