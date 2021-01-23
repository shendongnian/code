    if (ex.Status == WebExceptionStatus.ProtocolError)
     {
       using (WebResponse response = ex.Response)
    {
       HttpWebResponse httpResponse = (HttpWebResponse)response;
       listBox2.Items.Insert(0, "Status:" + httpResponse.StatusCode);
    }
     }
 
    else
    {
       listBox2.Items.Insert(0, "Status: " + ex.Status);
     }
