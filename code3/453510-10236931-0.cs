    public static class MyClass
    {
      public static void Forward()
      {
         /* snip */
      }
    
      [return: MarshalAs(UnmanagedType.Bool)]
      [DllImport("user32.dll", SetLastError = true)]
      static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    }
