    public void EndUpdate() 
    { 
      SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);  
      this.Invalidate();
    }
