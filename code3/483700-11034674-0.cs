    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class MouseWheelRedirector : IMessageFilter
    {
        private static MouseWheelRedirector instance = null;
        private static bool _active = false;
        public static bool Active
        {
           get { return _active; }
           set
           { 
              if (_active != value) 
              {
                 _active = value;
                 if (_active)
                 {
                    if (instance == null)
                    {
                        instance = new MouseWheelRedirector();
                    }
                    Application.AddMessageFilter(instance);
                 }
                 else
                 {
                    if (instance != null)
                    {
                       Application.RemoveMessageFilter(instance);
                    }
                 }
              }
           }
        }
    
        public static void Attach(Control control)
        {
           if (!_active)
              Active = true;
           control.MouseEnter += instance.ControlMouseEnter;
           control.MouseLeave += instance.ControlMouseLeaveOrDisposed;
           control.Disposed += instance.ControlMouseLeaveOrDisposed;
        }
    
        public static void Detach(Control control)
        {
           if (instance == null)
              return;
           control.MouseEnter -= instance.ControlMouseEnter;
           control.MouseLeave -= instance.ControlMouseLeaveOrDisposed;
           control.Disposed -= instance.ControlMouseLeaveOrDisposed;
           if (object.ReferenceEquals(instance.currentControl, control))
              instance.currentControl = null;
        }
    
        private MouseWheelRedirector()
        {
        }
    
    
        private Control currentControl;
        private void ControlMouseEnter(object sender, System.EventArgs e)
        {
           var control = (Control)sender;
           if (!control.Focused)
           {
              currentControl = control;
           }
           else
           {
              currentControl = null;
           }
        }
    
        private void ControlMouseLeaveOrDisposed(object sender, System.EventArgs e)
        {
           if (object.ReferenceEquals(currentControl, sender))
           {
              currentControl = null;
           }
        }
    
        private const int WM_MOUSEWHEEL = 0x20a;
        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
           if (currentControl != null && m.Msg == WM_MOUSEWHEEL)
           {
              SendMessage(currentControl.Handle, m.Msg, m.WParam, m.LParam);
              return true;
           }
           else
           {
              return false;
           }
        }
    
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr SendMessage(
           IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
     }
