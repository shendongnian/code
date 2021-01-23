    public int property
    {
        set
        {
             tbText.Text = value.ToString(); // value
        }
        get
        {
             // may want to do an int.TryParse here instead...
             return Convert.ToInt32(tbText.Text);
        }
    }
