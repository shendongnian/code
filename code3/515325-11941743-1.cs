    if (null != btn) {
        if (btn is Button) {
            ((Button)btn).Click += new EventHandler(SaveClicked);
            ScriptManager.GetCurrent(Page).RegisterAsyncPostBackControl(btn);
        }
    }
