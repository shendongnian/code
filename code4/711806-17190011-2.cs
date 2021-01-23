    [DllImport("user32")]
    private static extern IntPtr WindowFromPoint(POINT point);
    [DllImport("user32")]
    private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
    struct POINT
    {
      public int x, y;
    }
    private void MouseUp(object sender, MouseEventArgs e){
       if(DragHasStarted){
          DealWithDrag();
       }
       else {
          Point screenLocation = PointToScreen(e.Location);
          IntPtr childHandle = WindowFromPoint(new POINT{x=screenLocation.X,y=screenLocation.Y });
          if(childHandle != IntPtr.Zero){
             SendMessage(childHandle, 0x201, IntPtr.Zero, IntPtr.Zero);
             SendMessage(childHandle, 0x202, IntPtr.Zero, IntPtr.Zero);
          }
       }
    }
