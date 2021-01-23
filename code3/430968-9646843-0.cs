    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        SendMessage(Handle, 0x127, 0x10001, 0);
    }
    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        SendMessage(Handle, 0x127, 0x10001, 0);
    }
