     public partial class HeartbeatService : ServiceBase {
            readonly Timer _Timer = new System.Timers.Timer();
    
            private string _heartbeatTarget;
    
    
            public HeartbeatService() {
                Trace.TraceInformation("Initializing Heartbeat Service");
                InitializeComponent();
                this.ServiceName = "TavisHeartbeat";
            }
    
            protected override void OnStart(string[] args) {
                Trace.TraceInformation("Starting...");
                _Timer.Enabled = true;
    
                _Timer.Interval = Properties.Settings.Default.IntervalMinutes * 1000 * 60; 
                _Timer.Elapsed += new ElapsedEventHandler(_Timer_Elapsed);
    
                _heartbeatTarget = Properties.Settings.Default.TargetUrl; 
            }
    
            protected override void OnStop() {
                _Timer.Enabled = false;
            }
    
            private void _Timer_Elapsed(object sender, ElapsedEventArgs e) {
                Trace.TraceInformation("Heartbeat event triggered");
                try {
                    
                    var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(_heartbeatTarget);
                    httpWebRequest.ContentLength = 0;
                    httpWebRequest.Method = "POST";
                    var response = (HttpWebResponse)httpWebRequest.GetResponse();
                    Trace.TraceInformation("Http Response : " + response.StatusCode + " " + response.StatusDescription); 
                } catch (Exception ex) {
                    string errorMessage = ex.Message;
                    while (ex.InnerException != null) {
                        errorMessage = errorMessage + Environment.NewLine + ex.InnerException.Message;
                        ex = ex.InnerException;
                    }
                    Trace.TraceError(errorMessage);
                }
    
            }
    
    
        }
