          base.Install(stateSaver);
          try
          {
              ExecuteSqlScript();
          }
          catch (Insta`enter code here`llException ex)
          {
               throw ex;
          }
    
    }
    private void ExecuteSqlScript()
    {
          IntPtr hwnd = IntPtr.Zero;
          WindowWrapper wrapper = null;
          Process[] procs = Process.GetProcessesByName("msiexec");
          if (null != procs &amp;&amp; procs.Length &gt; 0)
             hwnd = procs[0].MainWindowHandle;
           wrapper = new WindowWrapper(hwnd);
           //Set the windows forms owner to setup project so it can be focused and
           //set infront
           frmInstance objInstance = new frmInstance();
           if (null != wrapper)
              objInstance.ShowDialog(wrapper);
           else
               objInstance.ShowDialog();
    }
    
     public class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            public WindowWrapper(IntPtr handle)
            {
                _hwnd = handle;
            }
    
            public IntPtr Handle
            {
                get { return _hwnd; }
            }
    
            private IntPtr _hwnd;
        }
