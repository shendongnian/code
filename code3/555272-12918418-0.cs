    try
    {
        using (var stream = t.Result.GetResponseStream())
        {
            DataContractJsonSerializer jsonSerializer = new
                DataContractJsonSerializer(typeof(Item));
            item = ((Item)jsonSerializer.ReadObject(stream));
        }
    }
    catch (AggregateException ex)
    {
        foreach (var e in ex.InnerExceptions)
        {
            bool isHandled = false;
            if (e is WebException)
            {
                WebException webException = (WebException)e;
                HttpWebResponse response = webException.Response as HttpWebResponse;
                if (response != null)
                {
                    code = response.StatusCode;
                    isHandled = true;
                }
            }
            
            if (!isHandled)
                throw;
        }
    }
