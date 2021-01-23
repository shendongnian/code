    {...
      WebBrowser wb = new WebBrowser();
      wb.NewWindow += new System.ComponentModel.CancelEventHandler(wb_NewWindow);
    }
    void wb_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
    {
        e.Cancel = true;
    }
