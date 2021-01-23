    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.IO;
    namespace wlchrUrl
    {
        class urlConn
        {
            public void DoConnect(string url)
            {
               Uri uri = new Uri(url);
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream stream= httpResponse.GetResponseStream();
                httpResponse.Close();
                stream.Close();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
