    public string url_check
    {
        set
        {
            if (!string.IsNullOrEmpty(url))
            {
                this._external= "";
            }
            else
            {
                this._external= "[external]";
            }
        }
    
    }  
