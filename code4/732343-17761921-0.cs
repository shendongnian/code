     public static String readWebLink(  String url)
                {
                    System.Net.WebClient client = new System.Net.WebClient();
                    byte[] data = client.DownloadData(url);
                    String html = System.Text.Encoding.UTF8.GetString(data);
                    return html;
      
                }
