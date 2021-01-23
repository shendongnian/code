    protected override void WndProc(ref System.Windows.Forms.Message message)
    {
        if (message.Msg == MY_CUSTOM_WINDOW_MSG_ID)
        {
            // PROCESS EVENT HERE
        }            
        base.WndProc(ref message);
    }
