    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if(!boolTrackingButtonPressed)
        {
           base.OnFormClosing(e);
        }
    }
