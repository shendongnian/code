    WebRequest request = (HttpWebRequest)WebRequest.Create("http://" + url.Host + "/favicon.ico");
    Icon ic = new Icon(); // put default here
    Bitmap bm = new Bitmap();
    try
    {
        using(WebResponse response = request.GetResponse())
        {
           using(Stream responseStream = response.GetResponseStream())
           {
              using(MemoryStream ms = new MemoryStream())
              {
                  var tmp = Image.FromStream(ms); // changed bitmap to image
                  bm = new Bitmap(tmp);
              }
           }
        }
    }catch{}
    if(bm != null)
    {
        ic = Icon.FromHandle(bm.GetHicon);  
    }
    return ic;
