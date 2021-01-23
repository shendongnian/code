    while (web.IsBusy)
        System.Windows.Forms.Application.DoEvents();
    for (int i = 0; i < 500; i++)
        if (web.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
       {
           System.Windows.Forms.Application.DoEvents();
           System.Threading.Thread.Sleep(10); 
       }
       else
           break;
    System.Windows.Forms.Application.DoEvents();
