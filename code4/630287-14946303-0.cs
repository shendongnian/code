    void _timer_Tick(object sender, EventArgs e)
    {
        try 
        {
            HttpWebRequest req = WebRequest.CreateHttp(_serverUrl + "channel.zip?_=" + Environment.TickCount);
            req.Method = "GET";
            req.BeginGetResponse(new AsyncCallback(WebComplete), req);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
