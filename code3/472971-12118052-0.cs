    private void CommandBars_OnUpdate()
    {
        if (mCommandButtonSendMeeting == null)
        {
            mCommandButtonSendMeeting = (CommandBarButton)CommandBars.FindControl(Missing.Value, 2617, Missing.Value, Missing.Value);
            mCommandButtonSendMeeting.Click += CommandButtonSendMeeting_Click;
        }
    }
    private void CommandButtonSendMeeting_Click(CommandBarButton Ctrl, ref bool CancelDefault)
    {
        CancelDefault = true;
        // Do whatever here.
    }
