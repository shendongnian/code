    private void SystemParametersClick(object sender, EventArgs e)
    {
        if (!_sp.Visible)
        {
            _sp.Show();
        }
        else
        {
            _sp.Activate();
        }
    }
