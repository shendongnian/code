    private WebClient webClient;
    private void Form1_Load(object sender, EventArgs e)
            {
                GetDataFromWebBrowser();
                Set_Auto_Refresh_Timer();
                this.webClient = new WebClient();
            }
    
    private void Set_Auto_Refresh_Timer()
            {
                System.Timers.Timer.TimerRefresh = new System.Timers.Timer(10000);
                TimerRefresh.Elapsed += new System.Timers.ElapsedEventHandler(TimerRefresh_Elapsed);
                TimerRefresh.AutoReset = true;
                TimerRefresh.Start();
            }    
    
    private void Set_Auto_Refresh_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                GetDataFromWebBrowser();
            }
    
    private void GetDataFromWebBrowser()
            {
                ...perform required work with webClient...
                ...get web data...
            }
