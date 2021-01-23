    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Add(...);
    return client.GetStringAsync(url).ContinueWith(task =>
    {
        try
        {
            return task.Result;
        }
        catch (AggregateException ex)
        {
            throw ex;
        }
        catch (WebException ex)
        {
            throw ex;
        }       
        catch (Exception ex)
        {
            throw ex;
        }
    });
