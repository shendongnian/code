    using System;
    using System.Windows.Forms;
    using MouseKeyboardActivityMonitor;
    using MouseKeyboardActivityMonitor.WinApi;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private readonly MouseHookListener m_MouseHookManager;
            public Form1()
            {
                InitializeComponent();
                m_MouseHookManager = new MouseHookListener(new GlobalHooker());
                m_MouseHookManager.Enabled = true;
                m_MouseHookManager.MouseWheel += HookManager_MouseWheel;
            }
            private void HookManager_MouseWheel(object sender, MouseEventArgs e)
            {
                labelWheel.Text = string.Format("Wheel={0:000}", e.Delta);
            }
        }
    }
