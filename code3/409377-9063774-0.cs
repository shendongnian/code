    public Uri Url
    {
        get
        {
            if (this._url == null && this._wr != null)
            {
                string text = this.QueryStringText;
                if (!string.IsNullOrEmpty(text))
                {
                    text = "?" + HttpUtility.CollapsePercentUFromStringInternal(text, this.QueryStringEncoding);
                }
                if (AppSettings.UseHostHeaderForRequestUrl)
                {
                    string knownRequestHeader = this._wr.GetKnownRequestHeader(28);
                    try
                    {
                        if (!string.IsNullOrEmpty(knownRequestHeader))
                        {
                            this._url = new Uri(string.Concat(new string[]
                            {
                                this._wr.GetProtocol(), 
                                "://", 
                                knownRequestHeader, 
                                this.Path, 
                                text
                            }));
                        }
                    }
                    catch (UriFormatException)
                    {
                    }
                }
                if (this._url == null)
                {
                    string text2 = this._wr.GetServerName();
                    if (text2.IndexOf(':') >= 0 && text2[0] != '[')
                    {
                        text2 = "[" + text2 + "]";
                    }
                    this._url = new Uri(string.Concat(new string[]
                    {
                        this._wr.GetProtocol(), 
                        "://", 
                        text2, 
                        ":", 
                        this._wr.GetLocalPortAsString(), 
                        this.Path, 
                        text
                    }));
                }
            }
            return this._url;
        }
    }
