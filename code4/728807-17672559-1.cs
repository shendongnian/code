    private void Mainform_Load(object sender, EventArgs e)
    {
        _tempCalib.OkClicked += CalibOkClicked;
    }
    private void CalibOkClicked(Object sender, EventArgs e)
    {
        StartTemp();
    }
