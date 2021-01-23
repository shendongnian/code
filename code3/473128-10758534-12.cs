    public string Url
    {
        get
        {
            EnsureChildControls();
            return txtUrl.Text;            
        }
        set
        {
            EnsureChildControls();
            txtUrl.Text = value;
        }
    }
