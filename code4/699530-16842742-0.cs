      set
      {
        Cursor cursor1 = (Cursor) this.Properties.GetObject(Control.PropCursor);
        Cursor cursor2 = this.Cursor;
        if (cursor1 != value)
        {
          System.Windows.Forms.IntSecurity.ModifyCursor.Demand();
          this.Properties.SetObject(Control.PropCursor, (object) value);
        }
        if (this.IsHandleCreated)
        {
          System.Windows.Forms.NativeMethods.POINT pt = new System.Windows.Forms.NativeMethods.POINT();
          System.Windows.Forms.NativeMethods.RECT rect = new System.Windows.Forms.NativeMethods.RECT();
          System.Windows.Forms.UnsafeNativeMethods.GetCursorPos(pt);
          System.Windows.Forms.UnsafeNativeMethods.GetWindowRect(new HandleRef((object) this, this.Handle), out rect);
          if (rect.left <= pt.x && pt.x < rect.right && (rect.top <= pt.y && pt.y < rect.bottom) || System.Windows.Forms.UnsafeNativeMethods.GetCapture() == this.Handle)
            this.SendMessage(32, this.Handle, (IntPtr) 1);
        }
        if (cursor2.Equals((object) value))
          return;
        this.OnCursorChanged(EventArgs.Empty);
      }
    }</pre></code>
You can see that there is a bunch of code executed every time.  There is check to see if the property has changed, but it only stops the framework from running a few lines.
