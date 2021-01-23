    if(e.Status == WebExceptionStatus.ProtocolError) {
        listBox.Items.Insert("Status Code : {0}", 
           ((HttpWebResponse)e.Response).StatusCode);
    }
    else
    {
        listBox.Items.Insert("Status : {0}", ex.Status);
    }
