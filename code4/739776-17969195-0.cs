    private bool CheckBox1Checked
    {
        get { return (ViewState["CheckBox1Checked"] as bool) ?? false; }
        set { ViewState["CheckBox1Checked"] = value; }
    }
    
    void Page_load(object sender, EventArgs e)
    {
    
        CheckBox cb = new CheckBox();
        cb.Text = "text";
        cb.ID = "1";
        cb.Checked = CheckBox1Checked;
        cb.OnCheckedChanged += CheckBox1OnChecked;
        // Add cb to control etc..
    }
    
    void CheckBox1OnChecked(object sender, EventArgs e)
    {
        var cb = (CheckBox)sender;
        CheckBox1Checked = cb.Checked;
    }
