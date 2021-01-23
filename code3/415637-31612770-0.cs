    // AccurateTimer.cs
    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace YourProjectsNamespace
    {
        class AccurateTimer
        {
            private delegate void TimerEventDel(int id, int msg, IntPtr user, int dw1, int dw2);
            private const int TIME_PERIODIC = 1;
            private const int EVENT_TYPE = TIME_PERIODIC;// + 0x100;  // TIME_KILL_SYNCHRONOUS causes a hang ?!
            [DllImport("winmm.dll")]
            private static extern int timeBeginPeriod(int msec);
            [DllImport("winmm.dll")]
            private static extern int timeEndPeriod(int msec);
            [DllImport("winmm.dll")]
            private static extern int timeSetEvent(int delay, int resolution, TimerEventDel handler, IntPtr user, int eventType);
            [DllImport("winmm.dll")]
            private static extern int timeKillEvent(int id);
    
            Action mAction;
            Form mForm;
            private int mTimerId;
            private TimerEventDel mHandler;  // NOTE: declare at class scope so garbage collector doesn't release it!!!
    
            public AccurateTimer(Form form,Action action,int delay)
            {
                mAction = action;
                mForm = form;
                timeBeginPeriod(1);
                mHandler = new TimerEventDel(TimerCallback);
                mTimerId = timeSetEvent(delay, 0, mHandler, IntPtr.Zero, EVENT_TYPE);
            }
    
            public void Stop()
            {
                int err = timeKillEvent(mTimerId);
                timeEndPeriod(1);
                System.Threading.Thread.Sleep(100);// Ensure callbacks are drained
            }
            private void TimerCallback(int id, int msg, IntPtr user, int dw1, int dw2)
            {
                if (mTimerId != 0)
                    mForm.BeginInvoke(mAction);
            }
        }
    }
    
    // FormMain.cs
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace YourProjectsNamespace
    {
        public partial class FormMain : Form
        {
            AccurateTimer mTimer1,mTimer2;
    
            public FormMain()
            {
                InitializeComponent();
            }
    
            private void FormMain_Load(object sender, EventArgs e)
            {
                int delay = 10;   // In milliseconds. 10 = 1/100th second.
                mTimer1 = new AccurateTimer(this, new Action(TimerTick1),delay);
                delay = 100;      // 100 = 1/10th second.
                mTimer2 = new AccurateTimer(this, new Action(TimerTick2), delay);
            }
    
            private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
            {
                mTimer1.Stop();
                mTimer2.Stop();
            }
    
            private void TimerTick1()
            {
                // Put your first timer code here!
            }
    
            private void TimerTick2()
            {
                // Put your second timer code here!
            }
        }
    }
