        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.IO;
        using System.Diagnostics;
        using System.Threading;
        namespace ThreadSample
        {
            public class XmlandRarCompletedEventArgs : EventArgs
            {
                public readonly bool Finished;
                public readonly bool Canceled;
                public XmlandRarCompletedEventArgs(bool finished)
                {
                    Finished = finished;
                    Canceled = !finished;
                }
            }
            public class OnXmlandRarUpdateEventArgs : EventArgs
            {
                public readonly int Percentage;
                public readonly string Message;
                public OnXmlandRarUpdateEventArgs(int perc) : this(perc, "")
                {
                }   
                public OnXmlandRarUpdateEventArgs(int perc, string message)
                {
                    Percentage = perc;
                    Message = message;
                }
            }
            public delegate void OnXmlandRarDoWorkHandler(object o);
            public delegate void OnXmlandRarUpdateHandler(object o, OnXmlandRarUpdateEventArgs args);
            public delegate void OnXmlandRarCompleteHandler(object o, XmlandRarCompletedEventArgs args);
            public class XMLandRar      // : BackgroundWorker
            {
                // Event handler to bind to for reporting progress
                public EventHandler<ProgressArgs> ReportProgress;
                // Eventargs to contain information to send to the subscriber
                public class ProgressArgs : EventArgs
                {
                    public int Percentage { get; set; }
                    public string Message { get; set; }
                }
                public event OnXmlandRarDoWorkHandler OnDoWork;
                public event OnXmlandRarUpdateHandler OnUpdate;
                public event OnXmlandRarCompleteHandler OnComplete;
                public void RarFiles(List<string> repSelected)
                {
                    TriggerDoWork();
                    int step = 100 / repSelected.Count();
                    int i = 0;
                    //Iterate through list and run rar for each
                    foreach (string rep in repSelected)
                    {
                        TriggerUpdate(i, "Raring files for " + rep);
                        //DirectoryExists(rep);
                        //ProcessRunner(rep);
                        i += step;
                        TriggerUpdate(i, "Raring files for " + rep);
                    }
                    TriggerComplete(true);
                }
                private void TriggerDoWork()
                {
                    if (OnDoWork != null)
                    {
                        OnDoWork(this);
                    }
                }
                private void TriggerUpdate(int perc)
                {
                    if (OnUpdate != null)
                    {
                        OnUpdate(this, new OnXmlandRarUpdateEventArgs(perc));
                    }
                }
                private void TriggerUpdate(int perc, string message)
                {
                    if (OnUpdate != null)
                    {
                        OnUpdate(this, new OnXmlandRarUpdateEventArgs(perc, message));
                    }
                }
                private void TriggerComplete(bool finished)
                {
                    if (OnComplete != null)
                    {
                        OnComplete(this, new XmlandRarCompletedEventArgs(finished));
                    }
                }
            }
        }
