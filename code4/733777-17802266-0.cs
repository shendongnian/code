    public bool StartFormB()
    {
        if (DisplayFrmB == null)
        {
            throw new ArgumentNullException("DisplayFrmB");
        }
       if (DisplayFrmB.InvokeRequired)
       {
        
            frB.Invoke(new EventHandler(DisplayFrmB));
       }
       else
       {    
          if (DisplayFrmB.IsDisposed)
          {
            throw new ObjectDisposedException("Control is already disposed.");
          }
      }
    
      return true;
    }
