    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace WindowsFormsExamples
    {
        public partial class OnlyOneThread : Form
        {
            List<ManualResetEvent> threadStopEvents;
            public OnlyOneThread()
            {
                InitializeComponent();
                threadStopEvents = new List<ManualResetEvent>();
            }
            private void runThreadBtn_Click(object sender, EventArgs e)
            {
                ManualResetEvent evt = new ManualResetEvent(false);
                ParameterizedThreadStart ts = new ParameterizedThreadStart(this.ThreadFunc);
                Thread t = new Thread(ts);
                t.Start(evt);
            }
            private delegate void UptadeThreadCountDelegate();
            private void UpdateThreadCount()
            {
                threadcountLbl.Text = threadStopEvents.Count.ToString();
            }
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                foreach (ManualResetEvent evt in threadStopEvents)
                {
                    evt.Set();
                }
            }
            private void ThreadFunc(Object obj)
            {
                ManualResetEvent stopEvent = obj as ManualResetEvent;
                lock (threadStopEvents)
                {
                    foreach (ManualResetEvent evt in threadStopEvents)
                    {
                        evt.Set();
                    }
                    threadStopEvents.Add(stopEvent);
                }
                if (this.IsHandleCreated) // This is necessary for invocation
                    this.Invoke(new UptadeThreadCountDelegate(this.UpdateThreadCount));
                for (int i = 0; i < 60; i++) // this will run about 1 minute
                {
                    if (stopEvent.WaitOne(0))
                    {
                        //Stop signaled!!! exit!
                        break;
                    }
                    Thread.Sleep(1000); //Sleep 1 second
                }
                lock (threadStopEvents)
                {
                    threadStopEvents.Remove(stopEvent); //remove stop event from list
                }
                if (this.IsHandleCreated) // This is necessary for invocation
                   this.Invoke(new UptadeThreadCountDelegate(this.UpdateThreadCount)); 
            }
        }
    }
