    public Uri Url {
      get {
        if (this._url == (Uri) null && this._wr != null) {
          string s = this.QueryStringText;
          if (!string.IsNullOrEmpty(s))
            s = "?" + HttpEncoder.CollapsePercentUFromStringInternal(s, this.QueryStringEncoding);
          if (AppSettings.UseHostHeaderForRequestUrl) {
            string knownRequestHeader = this._wr.GetKnownRequestHeader(28);
            try {
              if (!string.IsNullOrEmpty(knownRequestHeader))
                this._url = new Uri(this._wr.GetProtocol() + "://" + knownRequestHeader + this.Path + s);
            }
            catch (UriFormatException ex){}
          }
          if (this._url == (Uri) null) {
            string str = this._wr.GetServerName();
            if (str.IndexOf(':') >= 0 && (int) str[0] != 91)
              str = "[" + str + "]";
            this._url = new Uri(this._wr.GetProtocol() + "://" + str + ":" + this._wr.GetLocalPortAsString() + this.Path + s);
          }
        }
        return this._url;
      }
    }
