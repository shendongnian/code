        public class DuplexCallBackNotificationIntegrationExtension : IExtension, INotificationPusherCallback {
        #region - Field(s) -
        private static Timer _Timer = null;
        private static readonly object m_SyncRoot = new Object();
        private static readonly Guid CMESchedulerApplicationID = Guid.NewGuid();
        private static CancellationTokenSource cTokenSource = new CancellationTokenSource();
        private static CancellationToken cToken = cTokenSource.Token;
        #endregion
        #region - Event(s) -
        /// <summary>
        /// Event fired during Duplex callback.
        /// </summary>
        public static event EventHandler<CallBackEventArgs> CallBackEvent;
        public static event EventHandler<System.EventArgs> InstanceContextOpeningEvent;
        public static event EventHandler<System.EventArgs> InstanceContextOpenedEvent;
        public static event EventHandler<System.EventArgs> InstanceContextClosingEvent;
        public static event EventHandler<System.EventArgs> InstanceContextClosedEvent;
        public static event EventHandler<System.EventArgs> InstanceContextFaultedEvent;
        #endregion
        #region - Property(ies) -
        /// <summary>
        /// Interface extension designation.
        /// </summary>
        public string Name {
            get {
                return "Duplex Call Back Notification Integration Extension.";
            }
        }
        /// <summary>
        /// GUI Interface extension.
        /// </summary>
        public IUIExtension UIExtension {
            get {
                return null;
            }
        }
        #endregion
        #region - Constructor(s) / Finalizer(s) -
        /// <summary>
        /// Initializes a new instance of the DuplexCallBackNotificationIntegrationExtension class.
        /// </summary>
        public DuplexCallBackNotificationIntegrationExtension() {
            CallDuplexNotificationPusher();
        }
        #endregion
        #region - Delegate Invoker(s) -
        void ICommunicationObject_Opening(object sender, System.EventArgs e) {
            DefaultLogger.DUPLEXLogger.Info("context_Opening");
            this.OnInstanceContextOpening(e);
        }
        void ICommunicationObject_Opened(object sender, System.EventArgs e) {
            DefaultLogger.DUPLEXLogger.Debug("context_Opened");
            this.OnInstanceContextOpened(e);
        }
        void ICommunicationObject_Closing(object sender, System.EventArgs e) {
            DefaultLogger.DUPLEXLogger.Debug("context_Closing");
            this.OnInstanceContextClosing(e);
        }
        void ICommunicationObject_Closed(object sender, System.EventArgs e) {
            DefaultLogger.DUPLEXLogger.Debug("context_Closed");
            this.OnInstanceContextClosed(e);
        }
        void ICommunicationObject_Faulted(object sender, System.EventArgs e) {
            DefaultLogger.DUPLEXLogger.Error("context_Faulted");
            this.OnInstanceContextFaulted(e);
            if (_Timer != null) {
                _Timer.Dispose();
            }
            IChannel channel = sender as IChannel;
            if (channel != null) {
                channel.Abort();
                channel.Close();
            }
            DoWorkRoutine(cToken);
        }
        protected virtual void OnCallBackEvent(Notification objNotification) {
            if (CallBackEvent != null) {
                CallBackEvent(this, new CallBackEventArgs(objNotification));
            }
        }
        protected virtual void OnInstanceContextOpening(System.EventArgs e) {
            if (InstanceContextOpeningEvent != null) {
                InstanceContextOpeningEvent(this, e);
            }
        }
        protected virtual void OnInstanceContextOpened(System.EventArgs e) {
            if (InstanceContextOpenedEvent != null) {
                InstanceContextOpenedEvent(this, e);
            }
        }
        protected virtual void OnInstanceContextClosing(System.EventArgs e) {
            if (InstanceContextClosingEvent != null) {
                InstanceContextClosingEvent(this, e);
            }
        }
        protected virtual void OnInstanceContextClosed(System.EventArgs e) {
            if (InstanceContextClosedEvent != null) {
                InstanceContextClosedEvent(this, e);
            }
        }
        protected virtual void OnInstanceContextFaulted(System.EventArgs e) {
            if (InstanceContextFaultedEvent != null) {
                InstanceContextFaultedEvent(this, e);
            }
        }
        #endregion
        #region - IDisposable Member(s) -
        #endregion
        #region - Private Method(s) -
        /// <summary>
        /// 
        /// </summary>
        void CallDuplexNotificationPusher() {
            var routine = Task.Factory.StartNew(() => DoWorkRoutine(cToken), cToken);
            cToken.Register(() => cancelNotification());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        void DoWorkRoutine(CancellationToken ct) {
            lock (m_SyncRoot) {
                var context = new InstanceContext(this);
                var proxy = new NotificationPusherClient(context);
                ICommunicationObject communicationObject = proxy as ICommunicationObject;
                communicationObject.Opening += new System.EventHandler(ICommunicationObject_Opening);
                communicationObject.Opened += new System.EventHandler(ICommunicationObject_Opened);
                communicationObject.Faulted += new System.EventHandler(ICommunicationObject_Faulted);
                communicationObject.Closed += new System.EventHandler(ICommunicationObject_Closed);
                communicationObject.Closing += new System.EventHandler(ICommunicationObject_Closing);
                
                try {
                    proxy.Subscribe(CMESchedulerApplicationID.ToString());
                }
                catch (Exception ex) {
                    Logger.HELogger.DefaultLogger.DUPLEXLogger.Error(ex);                    
                    switch (communicationObject.State) {
                        case CommunicationState.Faulted:
                            proxy.Close();
                            break;
                        default:
                            break;
                    }
                    cTokenSource.Cancel();
                    cTokenSource.Dispose();                    
                    cTokenSource = new CancellationTokenSource();
                    cToken = cTokenSource.Token;
                    CallDuplexNotificationPusher();  
                }
                bool KeepAliveCallBackEnabled = Properties.Settings.Default.KeepAliveCallBackEnabled;
                if (KeepAliveCallBackEnabled) {
                    _Timer = new Timer(new TimerCallback(delegate(object item) {
                        DefaultLogger.DUPLEXLogger.Debug(string.Format("._._._._._. New Iteration {0: yyyy MM dd hh mm ss ffff} ._._._._._.", DateTime.Now.ToUniversalTime().ToString()));
                        DBNotificationPusherService.Acknowledgment reply = DBNotificationPusherService.Acknowledgment.NAK;
                        try {
                            reply = proxy.KeepAlive();
                        }
                        catch (Exception ex) {
                            DefaultLogger.DUPLEXLogger.Error(ex);
                            switch (communicationObject.State) {
                                case CommunicationState.Faulted:
                                case CommunicationState.Closed:
                                    proxy.Abort();
                                    ICommunicationObject_Faulted(null, null);
                                    break;
                                default:
                                    break;
                            }
                        }
                        DefaultLogger.DUPLEXLogger.Debug(string.Format("Acknowledgment = {0}.", reply.ToString()));
                        _Timer.Change(Properties.Settings.Default.KeepAliveCallBackTimerInterval, Timeout.Infinite);
                    }), null, Properties.Settings.Default.KeepAliveCallBackTimerInterval, Timeout.Infinite);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void cancelNotification() {
           DefaultLogger.DUPLEXLogger.Warn("Cancellation request made!!");
        }
        #endregion 
        #region - Public Method(s) -
        /// <summary>
        /// Fire OnCallBackEvent event and fill automatic-recording collection with newest 
        /// </summary>
        /// <param name="action"></param>
        public void SendNotification(Notification objNotification) {
            
            // Fire event callback.
            OnCallBackEvent(objNotification);
        }
        #endregion
        #region - Callback(s) -
        private void OnAsyncExecutionComplete(IAsyncResult result) {
        }
        #endregion
    }
