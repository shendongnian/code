      public partial class FormSender : Form
      {
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
    
        private static readonly int WM_REFRESH_CONFIGURATION = RegisterWindowMessage("WM_REFRESH_CONFIGURATION");
    
        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    
        public FormSender()
        {
          InitializeComponent();
        }
    
        private void btnNotify_Click(object sender, EventArgs e)
        {
          NotifyOtherApp();
        }
    
        private void NotifyOtherApp()
        {
          List<Process> procs = Process.GetProcesses().ToList();
          Process receiverProc = procs.Find(pp => pp.ProcessName == "Receiver" || pp.ProcessName == "Receiver.vshost");  
          if (receiverProc != null)
            PostMessage((IntPtr)receiverProc.MainWindowHandle, WM_REFRESH_CONFIGURATION, new IntPtr(0), new IntPtr(0));
        }
      }
