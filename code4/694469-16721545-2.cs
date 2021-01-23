    public partial class Form2 : Form {
      internal bool ForceActiveBar { get; set; }
      public Form2() {
        InitializeComponent();
        this.ShowInTaskbar = false;
        this.ForceActiveBar = true;
      }
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if (m.Msg == Win32.WM_NCACTIVATE) {
          if (this.ForceActiveBar && m.WParam == IntPtr.Zero) {
            Win32.SendMessageW(this.Handle, Win32.WM_NCACTIVATE, new IntPtr(1), IntPtr.Zero);
          }
        }
      }
    }
