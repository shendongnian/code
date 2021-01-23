    const string COREDLL = "coredll.dll";
    [DllImport(COREDLL, EntryPoint = "FindWindowW", SetLastError = true)]
    public static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
    [DllImport(COREDLL, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    private static Form1 objForm = null;
    private static IntPtr _taskBar = IntPtr.Zero;
    private static IntPtr _sipButton = IntPtr.Zero;
    [MTAThread]
    static void Main() {
      ShowWindowsMenu(false);
      try {
        objForm = new Form1();
        Application.Run(objForm);
      } catch (Exception err) {
        objForm.DisableTimer();
        if (!String.IsNullOrEmpty(err.Message)) {
          ErrorWrapper("AcpWM5 Form (Program)", err);
        }
      } finally {
        ShowWindowsMenu(true); // turns the menu back on
      }
    }
    private static void ShowWindowsMenu(bool enable) {
      try {
        if (enable) {
          if (_taskBar != IntPtr.Zero) {
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _taskBar = FindWindowCE("HHTaskBar", null); // Find the handle to the Start Bar
          if (_taskBar != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show Start" : "Hide Start", err);
      }
      try {
        if (enable) {
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 240, 26, (int)WindowPosition.SWP_SHOWWINDOW); // display the start bar
          }
        } else {
          _sipButton = FindWindowCE("MS_SIPBUTTON", "MS_SIPBUTTON");
          if (_sipButton != IntPtr.Zero) { // If the handle is found then hide the start bar
            SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 0, 0, (int)WindowPosition.SWP_HIDEWINDOW); // Hide the start bar
          }
        }
      } catch (Exception err) {
        ErrorWrapper(enable ? "Show SIP" : "Hide SIP", err);
      }
    }
