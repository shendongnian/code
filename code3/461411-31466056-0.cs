    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AllCommander.Diagnostics {
        public class SafeTimer : IDisposable {
    
            public enum IntervalStartTime {
                ElapsedStart,
                ElapsedFinish
            }
    
    
            private System.Timers.Timer InternalTimer;
    
            public bool AutoReset { get; set; }
    
            public bool Enabled {
                get {
                    return InternalTimer.Enabled;
                }
                set {
                    if (value) {
                        Start();
                    } else {
                        Stop();
                    }
                }
            }
    
    
            private double __Interval;
            public double Interval {
                get {
                    return __Interval;
                }
                set {
                    __Interval = value;
                    InternalTimer.Interval = value;
                }
            }
    
            /// <summary>
            /// Does the internal start ticking at the END of Elapsed or at the Beginning? 
            /// </summary>
            public IntervalStartTime IntervalStartsAt { get; set; }
    
            public event System.Timers.ElapsedEventHandler Elapsed;
    
    
            public SafeTimer() {
                InternalTimer = new System.Timers.Timer();
                InternalTimer.AutoReset = false;
                InternalTimer.Elapsed += InternalTimer_Elapsed;
    
                AutoReset = true;
                Enabled = false;
                Interval = 1000;
                IntervalStartsAt = IntervalStartTime.ElapsedStart;
            }
    
    
            void InternalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
    
                if (Elapsed != null) {
                    Elapsed(sender, e);
                }
    
                var ElapsedTime = DateTime.Now - e.SignalTime;
    
    
                if (AutoReset == true) {
                    //Our default interval will be INTERVAL ms after Elapsed finished.
                    var NewInterval = Interval;
                    if (IntervalStartsAt == IntervalStartTime.ElapsedStart) {
                        //If ElapsedStart is set to TRUE, do some fancy math to determine the new interval.
                        //If Interval - Elapsed is Positive, then that amount of time is remaining for the interval
                        //If it is zero or negative, we're behind schedule and should start immediately.
                        NewInterval = Math.Max(1, Interval - ElapsedTime.TotalMilliseconds);
                    }
    
                    InternalTimer.Interval = NewInterval;
    
                    InternalTimer.Start();
                }
    
            }
    
    
            public void Start() {
                Start(true);
            }
            public void Start(bool Immediately) {
                var TimerInterval = (Immediately ? 1 : Interval);
                InternalTimer.Interval = TimerInterval;
                InternalTimer.Start();
            }
    
            public void Stop() {
                InternalTimer.Stop();
            }
            
    
            #region Dispose Code
            //Copied from https://lostechies.com/chrispatterson/2012/11/29/idisposable-done-right/
            bool _disposed;
            public void Dispose() {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            ~SafeTimer() {
                Dispose(false);
            }
    
            protected virtual void Dispose(bool disposing) {
                if (!_disposed) {
                    if (disposing) {
                        InternalTimer.Dispose();
                    }
    
                    // release any unmanaged objects
                    // set the object references to null
                    _disposed = true;
                }
            }
            #endregion
        
        }
    }
