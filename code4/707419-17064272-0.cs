    protected void ModeSelectorSelectionChanged(object sender, EventArgs e)
    {
        var data1 = new string[]
                                        {
                                        "January 2012",
                                        "February 2012",
                                        "March 2012",
                                        "April 2012",
                                        };
        var data2 = new string[]
                                        {
                                        "Married",
                                        "Divorced",
                                        "Buy new house",
                                        "Get promotion",
                                        };
        if (_Menu2.SelectedIndex == 2)
        {
            _Menu3.DataSource = data1;
            _Menu3.DataBind();
        }
        else if (_Menu2.SelectedIndex == 3)
        {
            _Menu3.DataSource = data2;
            _Menu3.DataBind();
        }    
    }
