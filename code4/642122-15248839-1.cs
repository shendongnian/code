    public static async Task<bool> IsUriImage(Uri uri)
	{
            try
            {
                System.Net.WebRequest wc = System.Net.WebRequest.Create(uri); 
                //masquerade as a browser
                ((HttpWebRequest)wc).UserAgent = 
                  "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/0.2.153.1 Safari/525.19";
                wc.Timeout = 1000;
                wc.Method = "HEAD";
                using(WebResponse res = await wc.GetResponseAsync())
				{
					return 
                      res.ContentType
                       .StartsWith("image/",StringComparison.InvariantCulture);
				}
                
				
            }
            catch (Exception ex)
            {
                return false;
            }	
	}
