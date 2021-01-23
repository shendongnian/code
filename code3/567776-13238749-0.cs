    Show()
    {
        DisplayMessageBox();
        
        while(Ok button is not pressed)
        {
            WaitAFewMilliseconds();
        }
        HideMessageBox();
    }
