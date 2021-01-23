        public MainPage()
        {
            this.InitializeComponent();
            MainWebView.ScriptNotify += WebView_ScriptNotify;
        }
        void MainWebView_ScriptNotify(object sender, NotifyEventArgs e)
        {
            if (e.Value == "gotoPage2")
                this.Frame.Navigate(typeof(Page2));
        }
