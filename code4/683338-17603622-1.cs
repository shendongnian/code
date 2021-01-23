    public HttpCookie Get(string name)
    {
      HttpCookie cookie = (HttpCookie) this.BaseGet(name);
      if (cookie == null && this._response != null)
      {
        cookie = new HttpCookie(name);
        this.AddCookie(cookie, true);
        this._response.OnCookieAdd(cookie);
      }
      if (cookie != null)
        this.EnsureKeyValidated(name, cookie.Value);
      return cookie;
    }
