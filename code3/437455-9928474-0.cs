    public void CloseAll()
    {
        while (IE.InternetExplorersNoWait().Count > 0)
        {
            var ie = IE.InternetExplorersNoWait()[0];
            ie.ForceClose();
        }
    }
