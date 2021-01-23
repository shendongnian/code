    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    
    public class MainForm : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            new Thread(ProcessBitmap) { IsBackground = true }.Start(null);
            base.OnLoad(e);
        }
    
        void DoneProcessingBitmap(Bitmap bitmap)
        {
            Trace.WriteLine("Done Processing Bitmap");
            uiDoneEvent.Set();
        }
    
        AutoResetEvent uiDoneEvent = new AutoResetEvent(false);
        volatile bool terminate = false;
    
        void ProcessBitmap(object state)
        {
            while (!terminate)
            {
                Bitmap bitmap = (Bitmap)state;
                Trace.WriteLine("Processing Bitmap");
                Thread.Sleep(5000); // simulate processing
                BeginInvoke(new Action<Bitmap>(DoneProcessingBitmap), bitmap);
                Trace.WriteLine("Waiting");
                uiDoneEvent.WaitOne();
            }
        }
    
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
