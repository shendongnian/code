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
            List<ManualResetEvent> threadStopEvents;    //This will hold stop events for running threads
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
            private delegate void UptadeThreadCountDelegate();   //This delegate is used by Invoke method
            private void UpdateThreadCount()
            {
                threadcountLbl.Text = threadStopEvents.Count.ToString();
            }
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                //We must stop threads if they are still running
                lock (threadStopEvents)  // locking prevents simultaneous list access
                {
                    foreach (ManualResetEvent evt in threadStopEvents)
                    {
                        evt.Set(); //signal all events
                    }
                }
            }
            //This is thread function
            private void ThreadFunc(Object obj)
            {
                ManualResetEvent stopEvent = obj as ManualResetEvent; //cast an object that was passed by Thread.Start()
                lock (threadStopEvents) // locking prevents simultaneous list access
                {
                    foreach (ManualResetEvent evt in threadStopEvents)
                    {
                        evt.Set(); //signal all events for all other threads to stop
                    }
                    threadStopEvents.Add(stopEvent);  //Put our event on list
                }
                if (this.IsHandleCreated) // This is necessary for invocation
                    this.Invoke(new UptadeThreadCountDelegate(this.UpdateThreadCount));  //Invoke counter update
                for (int i = 0; i < 60; i++) // this will run about 1 minute
                {
                    if (stopEvent.WaitOne(0)) // Tests stopEvent and continues
                    {
                        //Stop signaled!!! exit!
                        break;
                    }
                    Thread.Sleep(1000); //Sleep 1 second
                }
                lock (threadStopEvents) // locking prevents simultaneous list access
                {
                    threadStopEvents.Remove(stopEvent); //remove stop event from list
                }
                if (this.IsHandleCreated) // This is necessary for invocation
                    this.Invoke(new UptadeThreadCountDelegate(this.UpdateThreadCount));  //Invoke counter update
            }
        }
    }
