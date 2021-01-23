    cmdBtn1.Click += OnCmdBtnClick;
    cmdBtn2.Click += OnCmdBtnClick;
    //...
    void OnCmdBtnClick(object sender, EventArgs e)
    {
        var btn = sender as Button;
        // ... do something ...
    }
