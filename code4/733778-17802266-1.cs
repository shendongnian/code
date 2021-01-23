    public bool StartFormB()
    {
        if (frB == null)
        {
            throw new ArgumentNullException("frB");
        }
       if (frB.InvokeRequired)
       {
        
            frB.Invoke(new EventHandler(DisplayFrmB));
       }
       else
       {    
          if (frB.IsDisposed)
          {
            throw new ObjectDisposedException("Control is already disposed.");
          }
      }
    
      return true;
    }
