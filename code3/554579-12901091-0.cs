    public void SetCommandExecute(object source)
    {       
        string source = source as string;
        if (source == "TheButton")
        {
           int val = Convert.ToInt32(this.VoltageText);
        }
    }
