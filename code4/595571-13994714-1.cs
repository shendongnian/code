    public string UserHostAddress
    {
        get
        {
            if (this._wr != null)
            {
                return this._wr.GetRemoteAddress();
            }
            return null;
        }
    }
