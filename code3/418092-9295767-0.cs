    private string currentUrl;
    
    public string CurrentUrl
    {
        get
        {
            if (string.IsNullOrEmpty(this.currentUrl))
            {
                string page = this.Page.ToString();
                this.currentUrl = page.Substring(4, page.Substring(4).Length - 5);
            }
            return this.currentUrl;
        }
    }
