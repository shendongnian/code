    protected override void OnClosing(CancelEventArgs e)
    {
       AnimateWindow(this.Handle, 500, AW_ACTIVATE | AW_SLIDE | AW_HOR_NEGATIVE | AW_HIDE);
    
       base.OnClosing(e);
    }
