    using System;
    using System.Collections.Generic;  
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using MouseKeyboardActivityMonitor;
    using MouseKeyboardActivityMonitor.WinApi;
    namespace WindowsFormsApplication1
    {
    
        public partial class Form1 : Form
        {
            private readonly KeyboardHookListener m_KeyboardHookManager;
            private readonly MouseHookListener m_MouseHookManager;
            public Form1()
            {
                InitializeComponent();
                m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
                m_KeyboardHookManager.Enabled = true;
                m_KeyboardHookManager.KeyDown += HookManager_KeyDown;
                m_KeyboardHookManager.KeyUp += HookManager_KeyUp;
                m_MouseHookManager = new MouseHookListener(new GlobalHooker());
                m_MouseHookManager.Enabled = true;
                m_MouseHookManager.MouseDown += HookManager_MouseDown;
                m_MouseHookManager.MouseUp += HookManager_MouseUp;
            }
            private void HookManager_KeyDown(object sender, KeyEventArgs e)
            {
                label1.Text = e.KeyValue.ToString() + " Pressed";
            }
            private void HookManager_KeyUp(object sender, KeyEventArgs e)
            {
                label1.Text = e.KeyValue.ToString() + " Released";
            }
            private void HookManager_MouseUp(object sender, MouseEventArgs e)
            {
                label1.Text = e.Button.ToString() + " Released";
            }
            private void HookManager_MouseDown(object sender, MouseEventArgs e)
            {
                label1.Text = e.Button.ToString() + " Pressed";
            }
        }
    }
