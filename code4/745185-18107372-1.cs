    public bool PlayDataToEnd
    {
        get
        {
            return this.PlayDataToEnd.SelectedIndex == 0;
        }
        set
        {
            this.PlayDataToEnd.SelectedIndex = value ? : 0 : 1;
        }
    }
