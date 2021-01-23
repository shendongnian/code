    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace FastLibrary
    {
        public enum Severity : byte
        {
            Info = 0,
            Error = 1,
            Debug = 2
        }
    
        public class Log
        {
            private struct LogMsg
            {
                public DateTime ReportedOn;
                public string Message;
                public Severity Seriousness;
            }
    
            // Nice and Threadsafe Singleton Instance
            private static Log _instance;
    
            public static Log File
            {
                get { return _instance; }
            }
    
            static Log()
            {
                _instance = new Log();
                _instance.Message("Started");
                _instance.Start("");
            }
    
             ~Log()
            {
                Exit();
            }
    
            public static void Exit()
            {
                if (_instance != null)
                {
                    _instance.Message("Stopped");
                    _instance.Stop();
                    _instance = null;
                }
            }
    
            private ConcurrentQueue<LogMsg> _queue = new ConcurrentQueue<LogMsg>();
            private Thread _thread;
            private string _logFileName;
            private volatile bool _isRunning;
    
            public void Message(string msg)
            {
                _queue.Enqueue(new LogMsg { ReportedOn = DateTime.Now, Message = msg, Seriousness = Severity.Info });
            }
    
            public void Message(DateTime time, string msg)
            {
                _queue.Enqueue(new LogMsg { ReportedOn = time, Message = msg, Seriousness = Severity.Info });
            }
    
            public void Message(Severity seriousness, string msg)
            {
                _queue.Enqueue(new LogMsg { ReportedOn = DateTime.Now, Message = msg, Seriousness = seriousness });
            }
    
            public void Message(DateTime time, Severity seriousness, string msg)
            {
                _queue.Enqueue(new LogMsg { ReportedOn = time, Message = msg, Seriousness = seriousness });
            }
    
            private void Start(string fileName = "", bool oneLogPerProcess = false)
            {
                _isRunning = true;
                // Unique FileName with date in it. And ProcessId so the same process running twice will log to different files
                string lp = oneLogPerProcess ? "_" + System.Diagnostics.Process.GetCurrentProcess().Id : "";
                _logFileName = fileName == ""
                                   ? DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") +
                                     DateTime.Now.Day.ToString("00") + lp + "_" +
                                     System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".log"
                                   : fileName;
                _thread = new Thread(LogProcessor);
                _thread.IsBackground = true;
                _thread.Start();
            }
    
            public void Flush()
            {
                EmptyQueue();
            }
    
            private void EmptyQueue()
            {
                while (_queue.Any())
                {
                    var strList = new List<string>();
                    //
                    try
                    {
                        // Block concurrent writing to file due to flush commands from other context
                        lock (_queue)
                        {
                            LogMsg l;
                            while (_queue.TryDequeue(out l)) strList.Add(l.ReportedOn.ToLongTimeString() + "|" + l.Seriousness + "|" + l.Message);
                            if (strList.Count > 0)
                            {
                                System.IO.File.AppendAllLines(_logFileName, strList);
                                strList.Clear();
                            }
                        }
                    }
                    catch
                    {
                        //ignore errors on errorlogging ;-)
                    }
                }
            }
    
            public void LogProcessor()
            {
                while (_isRunning)
                {
                    EmptyQueue();
                    // Sleep while running so we write in efficient blocks
                    if (_isRunning) Thread.Sleep(2000);
                    else break;
                }
            }
    
            private void Stop()
            {
                // This is never called in the singleton.
                // But we made it a background thread so all will be killed anyway
                _isRunning = false;
                if (_thread != null)
                {
                    _thread.Join(5000);
                    _thread.Abort();
                    _thread = null;
                }
            }
        }
    }                                                
