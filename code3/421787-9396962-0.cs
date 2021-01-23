    private bool _inStatusChange = false;
    private void OnAutomationStatusChanged(object sender, args...)
    {
        if (_inStatusChange)
        {
            return;
        }
        else
        {
             _inStatusChange = true;
            //do work
            _inStatusChange = false;
    
        }
    }
