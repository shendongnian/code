    public bool PlayDataToEnd
    {
        get
        {
            return this.PlayDataToEnd.SelectedValue.ToString() == "Yes";
        }
        set
        {
            this.PlayDataToEnd.SelectedValue = value ? "Yes" : "No";
        }
    }
