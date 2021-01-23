    WebClient client = new WebClient();
    foreach (HtmlElement row in webBrowser1.Document.Window.Frames["View_Frame"].Document.GetElementsByTagName("input"))
      {
        if (row.Name == "DOWNLOADALL")
          {
            row.InvokeMember("click");
            tbState.Text = "4";
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            client.DownloadFile(URL, path);//I don't know where is your URL and path!
            break;
          }
     }
                
