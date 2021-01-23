    try
    {
          // Stop redrawing:
          SendMessage(panel1.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
          // Stop sending of events:
          eventMask = SendMessage(panel1.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
     
          // code here
    }
    finally
    {
          // turn on events
          SendMessage(panel1.Handle, EM_SETEVENTMASK, 0, eventMask);
          // turn on redrawing
          SendMessage(panel1.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
    }
