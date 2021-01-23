      using System;
      using System.Timers;
      using System.Windows.Forms;
    
    
      public class SwitchForms : IDisposable
      {
        private Form Form1 { get; set; }
    
        private Form Form2 { get; set; }
    
        private System.Timers.Timer VisibilityTimer { get; set; }
    
    
        public SwitchForms(Form form1, Form form2, double hideMinutes)
        {
            Form1 = form1;
            Form2 = form2;
    
            VisibilityTimer = new System.Timers.Timer(hideMinutes * 60.0 * 1000.0);
            VisibilityTimer.Elapsed += VisibilityTimer_Elapsed;
            VisibilityTimer.Enabled = true;
    
    
            Form1.Invoke(new MethodInvoker(() => Form1.Show()));
            Form2.Invoke(new MethodInvoker(() => Form2.Hide()));
    
        }
    
        private void VisibilityTimer_Elapsed(object source, ElapsedEventArgs e)
        {
          if(Form1 == null || Form2 == null)
          {
            VisibilityTimer.Enabled = false;
            return;
          }
    
          if (Form1.IsDisposed || Form2.IsDisposed)
          {
            VisibilityTimer.Enabled = false;
            Form1 = null;
            Form2 = null;
          }
          else
          {
            Form1.Invoke(new MethodInvoker(() => { if(Form1.Visible) { Form1.Hide(); } else {Form1.Show();} }));
            Form2.Invoke(new MethodInvoker(() => { if (Form2.Visible) { Form2.Hide(); } else { Form2.Show(); } }));
          }
        }
    
        public void Dispose()
        {
          VisibilityTimer.Enabled = false;
          VisibilityTimer.Dispose();
        }
    
    
    
      }
    
    }
