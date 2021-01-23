    protected override void OnClientSizeChanged(EventArgs e)
    {
        base.OnClientSizeChanged(e);
        HScrollBar.Location = new Point(0, base.ClientSize.Height - HScrollBar.Height);
        HScrollBar.Width = base.ClientSize.Width - VScrollBar.Width;
        VScrollBar.Location = new Point(base.ClientSize.Width - VScrollBar.Width, 0);
        VScrollBar.Height = base.ClientSize.Height - HScrollBar.Height;
        cornerPanel.Size = new Size(VScrollBar.Width, HScrollBar.Height);
        cornerPanel.Location = new Point(base.ClientSize.Width - cornerPanel.Width, base.ClientSize.Height - cornerPanel.Height);
    }
