    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;
    using System.Security;
    using System.Security.Permissions;
    using System.Threading;
    namespace ScheduledWorker
    {
        /// <summary>
        /// Executes a recurring operation on a separate thread.
        /// </summary>
        [DefaultEvent("DoWork")]
        [HostProtection(SharedState = true)]
        public partial class ScheduledWorker : Component, ISupportInitialize
        {
            private bool enabled;
            private bool delayedEnable;
            private bool initializing;
            private bool disposed;
            private bool cancellationPending;
            private bool isRunning;
            private bool isOccupied;
            private bool isWorking;
            private object argument;
            private readonly object statusChangeLockObject = new object();
            private readonly object doWorkKey = new object();
            private readonly object runWorkerCompletedKey = new object();
            private readonly object progressChangedKey = new object();
            private readonly EventHandler<DoScheduledWorkEventArgs> workHandler;
            private readonly SendOrPostCallback completedCallback;
            private readonly SendOrPostCallback progressCallback;
            private AsyncOperation mainThreadOperation;
            private Timer timer;
            private double interval;
            /// <summary>
            /// Initializes a new instance of the ScheduledWorker class and sets the <see cref="ScheduledWorker.Interval"/> property to 100 milliseconds.
            /// </summary>
            public ScheduledWorker() : this(100) { }
            /// <summary>
            /// Initializes a new instance of the ScheduledWorker class, and sets the <see cref="ScheduledWorker.Interval"/> property to the specified number of milliseconds.
            /// </summary>
            /// <param name="interval">The time, in milliseconds, between events. The value must be greater than zero and less than or equal to <see cref="int.MaxValue"/>."/></param>
            public ScheduledWorker(double interval) : base()
            {
                this.interval = interval;
                completedCallback = new SendOrPostCallback(AsynOperationCompleted);
                progressCallback = new SendOrPostCallback(ProgressReporter);
                initializing = false;
                delayedEnable = false;
                workHandler = new EventHandler<DoScheduledWorkEventArgs>(WorkerThreadStart);
            }
            /// <summary>
            /// Occurs when <see cref="ScheduledWorker.RunWorkerAsync"/> or <see cref="ScheduledWorker.RunWorkerAsync(object)"/> are called.
            /// </summary>
            public event EventHandler<DoScheduledWorkEventArgs> DoWork
            {
                add
                {
                    Events.AddHandler(doWorkKey, value);
                }
                remove
                {
                    Events.RemoveHandler(doWorkKey, value);
                }
            }
            /// <summary>
            /// Occurs when the background operation has completed, has been canceled, or has raised an exception.
            /// </summary>
            public event EventHandler<RunWorkerCompletedEventArgs> RunWorkerCompleted
            {
                add
                {
                    Events.AddHandler(runWorkerCompletedKey, value);
                }
                remove
                {
                    Events.RemoveHandler(runWorkerCompletedKey, value);
                }
            }
            /// <summary>
            /// Occurs when <see cref="ScheduledWorker.ReportProgress(int)"/> or <see cref="ScheduledWorker.ReportProgress(int, object)"/> are called.
            /// </summary>
            public event EventHandler<ProgressChangedEventArgs> ProgressChanged
            {
                add
                {
                    Events.AddHandler(progressChangedKey, value);
                }
                remove
                {
                    Events.RemoveHandler(progressChangedKey, value);
                }
            }
            /// <summary>
            /// Starts raising the <see cref="ScheduledWorker.DoWork"/> event by setting Enabled to true.
            /// </summary>
            public void RunWorkerAsync()
            {
                RunWorkerAsync(null);
            }
            /// <summary>
            /// Starts raising the <see cref="ScheduledWorker.DoWork"/> event by setting Enabled to true.
            /// </summary>
            /// <param name="argument">A parameter for use by the background operation to be executed in the <see cref="ScheduledWorker.DoWork"/> event handler.</param>
            public void RunWorkerAsync(object argument)
            {
                Argument = argument;
                Enabled = true;
            }
            /// <summary>
            /// Stops raising the <see cref="ScheduledWorker.DoWork"/> event by setting Enabled to false.
            /// </summary>
            public void Stop()
            {
                Enabled = false;
            }
            /// <summary>
            /// Gets or sets a value indicating whether the <see cref="ScheduledWorker.DoWork"/> event should be raised.
            /// </summary>
            [Category("Behavior")]
            public bool Enabled
            {
                get
                {
                    lock (statusChangeLockObject)
                    {
                        return enabled;
                    }
                }
                set
                {
                    if (DesignMode)
                    {
                        delayedEnable = value;
                        enabled = value;
                    }
                    else if (initializing)
                    {
                        delayedEnable = value;
                    }
                    else if (enabled != value)
                    {
                        lock (statusChangeLockObject)
                        {
                            if (!value)
                            {
                                if (timer != null)
                                {
                                    timer.Dispose();
                                    timer = null;
                                }
                                enabled = false;
                                if (!isWorking)
                                {
                                    if (!isOccupied)
                                    {
                                        isRunning = false;
                                    }
                                    SetMainThreadOperationCompleted();
                                }
                            }
                            else
                            {
                                enabled = true;
                                if (timer == null && !isRunning)
                                {
                                    if (disposed)
                                    {
                                        throw new ObjectDisposedException(GetType().Name);
                                    }
                                    else
                                    {
                                        int roundedInterval = Convert.ToInt32(Math.Ceiling(interval));
                                        isRunning = true;
                                        isOccupied = false;
                                        isWorking = false;
                                        cancellationPending = false;
                                        SetMainThreadOperationCompleted();
                                        mainThreadOperation = AsyncOperationManager.CreateOperation(null);
                                        timer = new Timer(MyTimerCallback, null, roundedInterval, roundedInterval);
                                    }
                                }
                                else if (isRunning)
                                {
                                    throw new InvalidOperationException("Dieser ScheduledWorker ist derzeit ausgelastet und kann nicht mehrere Aufgaben gleichzeitig ausführen.");
                                }
                                else
                                {
                                    UpdateTimer();
                                }
                            }
                        }
                    }
                }
            }
            /// <summary>
            /// Gets or sets the interval, expressed in milliseconds, at which to raise the <see cref="ScheduledWorker.DoWork"/> event.
            /// It can be changed while the ScheduledWorker is running.
            /// </summary>
            [Category("Behavior"), DefaultValue(100d), SettingsBindable(true)]
            public double Interval
            {
                get
                {
                    return interval;
                }
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Das Startintervall muss grösser als 0 sein.");
                    }
                    else
                    {
                        interval = value;
                        if (timer != null)
                        {
                            UpdateTimer();
                        }
                    }
                }
            }
            /// <summary>
            /// Gets or sets a value indicating whether the ScheuledWorker can report progress updates.
            /// </summary>
            [DefaultValue(false)]
            public bool WorkerReportsProgress { get; set; }
            /// <summary>
            /// Raises the ProgressChanged event.
            /// </summary>
            /// <param name="percentProgress">The percentage, from 0 to 100, of the background operation that is complete.</param>
            public void ReportProgress(int percentProgress)
            {
                ReportProgress(percentProgress, null);
            }
            /// <summary>
            /// Raises the ProgressChanged event.
            /// </summary>
            /// <param name="percentProgress">The percentage, from 0 to 100, of the background operation that is complete.</param>
            /// <param name="userState">The state object passed to <see cref="ScheduledWorker.RunWorkerAsync(object)"/>.</param>
            public void ReportProgress(int percentProgress, object userState)
            {
                if (!WorkerReportsProgress)
                {
                    throw new InvalidOperationException("Dieser ScheduledWorker unterstützt keine Fortschrittsmitteilung");
                }
                else
                {
                    mainThreadOperation.Post(progressCallback, new ProgressChangedEventArgs(percentProgress, userState));
                }
            }
            /// <summary>
            /// Gets or sets a value indicating whether the ScheduledWorker supports asynchronous cancellation.
            /// </summary>
            [DefaultValue(false)]
            public bool WorkerSupportsCancellation { get; set; }
            /// <summary>
            /// Gets a value indicating whether the application has requested cancellation of a background operation.
            /// </summary>
            [Browsable(false)]
            public bool CancellationPending
            {
                get
                {
                    lock (statusChangeLockObject)
                    {
                        return cancellationPending;
                    }
                }
            }
            /// <summary>
            /// Requests cancellation of a pending background operation.
            /// </summary>
            public void CancelAsync()
            {
                if (!WorkerSupportsCancellation)
                {
                    throw new InvalidOperationException("Dieser ScheduledWorker unterstützt keinen Abbruch");
                }
                else
                {
                    lock (statusChangeLockObject)
                    {
                        cancellationPending = true;
                        Stop();
                    }
                }
            }
            /// <summary>
            /// Gets a value indicating whether the ScheduledWorker is running an asynchronous operation. This is the case until the SchedeuledWorker has been stopped (<see cref="ScheduledWorker.Enabled"/> = false) 
            /// and the last <see cref="ScheduledWorker.DoWork"/> event has completed.
            /// </summary>
            [Browsable(false)]
            public bool IsBusy
            {
                get
                {
                    lock (statusChangeLockObject)
                    {
                        return isRunning;
                    }
                }
            }
            /// <summary>
            /// A parameter for use by the background operation to be executed in the <see cref="ScheduledWorker.DoWork"/> event handler.
            /// It can be changed while the ScheduledWorker is running.
            /// </summary>
            [Browsable(false)]
            public object Argument
            {
                get
                {
                    return Interlocked.Exchange(ref argument, argument);
                }
                set
                {
                    Interlocked.Exchange(ref argument, value);
                }
            }
            /// <summary>
            /// Begins the run-time initialization of a ScheduledWorker that is used on a form or by another component.
            /// </summary>
            public void BeginInit()
            {
                Close();
                initializing = true;
            }
            /// <summary>
            /// Ends the run-time initialization of a ScheduledWorker that is used on a form or by another component.
            /// </summary>
            public void EndInit()
            {
                initializing = false;
                enabled = delayedEnable;
            }
            private void MyTimerCallback(object state)
            {
                lock (statusChangeLockObject)
                {
                    if (enabled && !isOccupied)
                    {
                        isOccupied = true;
                        isWorking = true;
                        FILE_TIME fileTime = new FILE_TIME();
                        SafeNativeMethods.GetSystemTimeAsFileTime(ref fileTime);
                        workHandler.BeginInvoke(this, 
                                                new DoScheduledWorkEventArgs(Argument,
                                                                             DateTime.FromFileTime((long)((((ulong)fileTime.ftTimeHigh) << 32) | (((ulong)fileTime.ftTimeLow) & 0xffffffff)))), 
                                                null, 
                                                null);
                    }
                }
            }
            private void WorkerThreadStart(object sender, DoScheduledWorkEventArgs args)
            {
                Exception Error = null;
                try
                {
                    if (CancellationPending)
                    {
                        args.Cancel = true;
                    }
                    else
                    {
                        OnDoWork(args);
                    }
                    if (args.Cancel)
                    {
                        args.Result = null;
                        cancellationPending = true;
                    }
                }
                catch (Exception ex)
                {
                    Error = ex;
                    args.Result = null;
                }
                finally
                {
                    mainThreadOperation.Post(completedCallback, new RunWorkerCompletedEventArgs(args.Result, Error, args.Cancel));
                }
            }
            protected void OnDoWork(DoScheduledWorkEventArgs args)
            {
                ((EventHandler<DoScheduledWorkEventArgs>)Events[doWorkKey])?.Invoke(this, args);
            }
            private void AsynOperationCompleted(object args)
            {
                lock (statusChangeLockObject)
                {
                    isWorking = false;
                    if (!enabled)
                    {
                        isRunning = false;
                        SetMainThreadOperationCompleted();
                    }
                }
                OnRunWorkerCompleted((RunWorkerCompletedEventArgs)args);
                lock (statusChangeLockObject)
                {
                    isOccupied = false;
                    if (!enabled)
                    {
                        isRunning = false;
                        SetMainThreadOperationCompleted();
                    }
                }
            }
            
            protected void OnRunWorkerCompleted(RunWorkerCompletedEventArgs args)
            {
                ((EventHandler<RunWorkerCompletedEventArgs>)Events[runWorkerCompletedKey])?.Invoke(this, args);
            }
            private void SetMainThreadOperationCompleted()
            {
                if (mainThreadOperation != null)
                {
                    mainThreadOperation.OperationCompleted();
                    mainThreadOperation = null;
                }
            }
            private void ProgressReporter(object arg)
            {
                OnProgressChanged((ProgressChangedEventArgs)arg);
            }
            protected void OnProgressChanged(ProgressChangedEventArgs args)
            {
                ((EventHandler<ProgressChangedEventArgs>)Events[progressChangedKey])?.Invoke(this, args);
            }
            private void UpdateTimer()
            {
                int roundedInterval = Convert.ToInt32(Math.Ceiling(interval));
                timer.Change(roundedInterval, roundedInterval);
            }
            public void Close()
            {
                initializing = false;
                delayedEnable = false;
                enabled = false;
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
                SetMainThreadOperationCompleted();
            }
            [StructLayout(LayoutKind.Sequential)]
            internal struct FILE_TIME
            {
                internal int ftTimeLow;
                internal int ftTimeHigh;
            }
            private sealed class SafeNativeMethods
            {
                [ResourceExposure(ResourceScope.None)]
                [DllImport("Kernel32"), SuppressUnmanagedCodeSecurityAttribute()]
                internal static extern void GetSystemTimeAsFileTime(ref FILE_TIME lpSystemTimeAsFileTime);
            }
        }
        /// <summary>
        /// Provides data for the <see cref="ScheduledWorker.DoWork"/> event.
        /// </summary>
        public sealed class DoScheduledWorkEventArgs : DoWorkEventArgs
        {
            internal DoScheduledWorkEventArgs(object arg, DateTime signalTime) : base(arg)
            {
                SignalTime = signalTime;
            }
            /// <summary>
            /// Gets the date/time when the <see cref="ScheduledWorker.DoWork"/> event was raised.
            /// </summary>
            public DateTime SignalTime { get; }
        }
    }
