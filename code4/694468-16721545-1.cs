    public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
      }
      private bool ignoreNcActivate = false;
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        switch (m.Msg) {
          case Win32.WM_NCACTIVATE:
            if (m.WParam == IntPtr.Zero) {
              if (ignoreNcActivate) {
                ignoreNcActivate = false;
              } else {
                Win32.SendMessageW(this.Handle, Win32.WM_NCACTIVATE, new IntPtr(1), IntPtr.Zero);
              }
            }
            break;
          case Win32.WM_ACTIVATEAPP:
            if (m.WParam == IntPtr.Zero) {
              Win32.PostMessageW(this.Handle, Win32.WM_NCACTIVATE, IntPtr.Zero, IntPtr.Zero);
              foreach (Form2 f in this.OwnedForms.OfType<Form2>()) {
                f.ForceActiveBar = false;
                Win32.PostMessageW(f.Handle, Win32.WM_NCACTIVATE, IntPtr.Zero, IntPtr.Zero);
              }
              ignoreNcActivate = true;
            } else if (m.WParam == new IntPtr(1)) {
              Win32.SendMessageW(this.Handle, Win32.WM_NCACTIVATE, new IntPtr(1), IntPtr.Zero);
              foreach (Form2 f in this.OwnedForms.OfType<Form2>()) {
                f.ForceActiveBar = true;
                Win32.SendMessageW(f.Handle, Win32.WM_NCACTIVATE, new IntPtr(1), IntPtr.Zero);
              }
            }
            break;
        }
      }
      protected override void OnShown(EventArgs e) {
        base.OnShown(e);
        Form2 f = new Form2();
        f.Show(this);
      }
    }
