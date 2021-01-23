    public int property
    {
        set
        {
            tbText.Text = value.ToString();
        }
        get
        {
            return Convert.ToInt32(tbText.Text);
        }
    }
