    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace LeaveTest {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e) {
                base.OnLoad(e);
                textBox2.LostFocus += new EventHandler(textBox2_LostFocus);
            }
    
            void textBox2_LostFocus(object sender, EventArgs e) {
                Control newControl = GetCurrentControl();
                Control prevControl = GetPrevControl(textBox2);
                Control nextControl = GetNextControl(textBox2);
    
                if (newControl.Handle == prevControl.Handle) {
                    MessageBox.Show("Case 4");
                }
            }
    
            [DllImport("user32.dll")]
            static extern IntPtr GetFocus();
    
            [DllImport("user32.dll")]
            static extern IntPtr GetNextDlgTabItem(IntPtr hDlg, IntPtr hCtl,
               bool bPrevious);
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);
    
            enum GetWindow_Cmd : uint {
                GW_HWNDFIRST = 0,
                GW_HWNDLAST = 1,
                GW_HWNDNEXT = 2,
                GW_HWNDPREV = 3,
                GW_OWNER = 4,
                GW_CHILD = 5,
                GW_ENABLEDPOPUP = 6
            }
    
    
            private Control GetCurrentControl() {
                IntPtr hWnd = GetFocus();
                Control control = Control.FromHandle(hWnd);
                return control;
            }
    
            private Control GetNextControl(Control ctrl) {
                // I know the last parameter looks wierd, but it works
                IntPtr hWnd = GetNextDlgTabItem(ctrl.Parent.Handle, ctrl.Handle, true);
    
                Control control = Control.FromHandle(hWnd);
                return control;
            }
    
            private Control GetPrevControl(Control ctrl) {
                // I know the last parameter looks wierd, but it works
                IntPtr hWnd = GetNextDlgTabItem(ctrl.Parent.Handle, ctrl.Handle, false);
                Control control = Control.FromHandle(hWnd);
                return control;
            }
        }
    }
