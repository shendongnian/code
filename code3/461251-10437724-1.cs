    protected override void RaisePostBackEvent(IPostBackEventHandler source, string eventArgument)
    {
        base.RaisePostBackEvent(source, eventArgument);
        if (source == txtInput)
        {
            plcLoadedControls.Controls.Add(new LiteralControl("Hello World!"));
        }
    }
