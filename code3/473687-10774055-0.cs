    public partial class GuestForm: Form
    {
      [DllImport("user32.dll")]
      public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
      [DllImport("user32.dll")]
      public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    
      [DllImport("user32.dll", SetLastError = true)]
      private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
      public static int GWL_STYLE = -16;
      public static int WS_CHILD = 0x40000000; 
      public GuestForm()
      {
        InitializeComponent();
      }
      private void button1_Click(object sender, EventArgs e)
      {
        MessageBox.Show("done");
      }
      private void button2_Click(object sender, EventArgs e)
      {
        Process hostProcess = Process.GetProcessesByName("HostFormApp").FirstOrDefault();
        if (hostProcess != null)
        {
          Hide();
          FormBorderStyle = FormBorderStyle.None;
          SetBounds(0, 0, 0, 0, BoundsSpecified.Location);
          IntPtr hostHandle = hostProcess.MainWindowHandle;
          IntPtr guestHandle = this.Handle;
          SetWindowLong(guestHandle, GWL_STYLE, GetWindowLong(guestHandle, GWL_STYLE) | WS_CHILD);
          SetParent(guestHandle, hostHandle);
          Show();
        }
      }
    }
 
