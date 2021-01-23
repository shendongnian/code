    public void set_Checked(bool value)
    {
        if (value != this.Checked)
        {
            this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
        }
    }
 
 
