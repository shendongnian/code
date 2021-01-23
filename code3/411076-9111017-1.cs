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
                  bm = Bitmap.FromStream(ms);
              }
           }
        }
    }catch{}
    if(bm != null)
    {
        var iconHandle = bm.GetHicon();
        ic = System.Drawing.Icon.FromHandle(iconHandle);
    }
    return ic;
