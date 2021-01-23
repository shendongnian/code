    public bool? Checked {get; private set;}
    public void setChecked(String value)
    {
        if (value == "")
           _checked = null;
        else if (value.ToLower() == "true")
           _checked = true;
        else
           _checked = false;
    }
