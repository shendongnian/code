    public string UserID
    {
        get { return textBlock1.Text; }
        set
        {
            textBlock1.Text = value;
            groupBox1.Header = value;
        }
    }
