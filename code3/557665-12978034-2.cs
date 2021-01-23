    if (System.Windows.Forms.Application.MessageLoop) 
    {
        // WinForms app
        System.Windows.Forms.Application.Exit();
    }
    else
    {
        // Console app
        System.Environment.Exit(1);
    }
