    private void FinishWebRequest(IAsyncResult result)
    {
        try
        {
            // handle response
        }
        catch (WebException webEx)
        {
            if (webEx.Status != WebExceptionStatus.RequestCanceled)
            {
                IsDownload = false;
                failCallback();
            }
        }
        catch
        {
            IsDownload = false;
            failCallback();
        }
    }
