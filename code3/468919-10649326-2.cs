    public string Status // Change signature of property 
    {
        get 
        { 
           return status; 
        }
        set 
        {
            status = value;
            Refresh();
        } 
    }
    private void Refresh()
    {
        lblStatus.Text = Status.ToString();
    }
