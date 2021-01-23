    public string Value 
    {
        get 
        { 
            return value; 
        }
        set 
        { 
            this.value = value; 
            this.Text = Transform(value); // change the label here
        }
    }
