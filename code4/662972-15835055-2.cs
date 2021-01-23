    string URI = "http://ww.exmaple.com.tr/webservices/addlead.php?";
    string myParameters = "first_name=" + r.Name + "&last_name=" + r.Surname + "&phone=" + r.Telephone + "&hash=" + r.HashCode;
    URI += myParameters;
    
    using (WebClient wc = new WebClient())
    {
     try
     {
      wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
      string HtmlResult = wc.DownloadString(URI);
     }
     catch(Exception ex)
     {
      // handle error
      MessageBox.Show( ex.Message );
     }
    }
