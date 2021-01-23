    public int property
    {
        get
        {             
             int defaultVal;
             int.TryParse(tbText.Text, out defaultVal);
             return defaultVal;
        }
        set
        {
             tbText.Text = value.ToString(); // value
        }
    }
