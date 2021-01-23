    public void CancelGoogleRequest()
    {
        if (IsDownload)
        {
            IsDownload = false; // set before Abort
            IsAborting = true;
            request.Abort();
            IsAborting = false;
        }
    }
