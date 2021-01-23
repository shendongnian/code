    private int Temp
    {
        get
        {
            if(this.ViewState["temp"] == null)
                return 0;
    
            return int.Parse(this.ViewState["temp"].ToString());
        }
        set
        {
            this.ViewState["temp"] = value;
        }
    }
