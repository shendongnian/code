    public void CancelGoogleRequest()
    {
        if (IsDownload)
        {
            IsDownload = false; // set before Abort
            request.Abort();
        }
    }
