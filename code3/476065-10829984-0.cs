    static void Main(string[] args)
    {
      try
      {
        SplashScreen.ShowSplashScreen();
        Application.DoEvents();
        SplashScreen.WaitForVisibility(.5);
        bool starting = true;
        while (starting)
        {
          try
          {
    	    SplashScreen.SetStatus("Initialize mainform...");
    	    starting = false;
    	    Application.Run(new MainForm());
          }
          catch (Exception ex)
          {
            if (starting)
    	      starting = XtraMessageBox.Show(ex.Message, "Fout bij initialiseren", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Retry;
    	    else
    	      throw (ex);
          }
        }
      }
      catch (Exception ex)
      {
        if (ex is object)
          XtraMessageBox.Show(ex.Message, "Algemene fout", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
      }
    }
