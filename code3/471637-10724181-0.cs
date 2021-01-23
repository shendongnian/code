    public partial class dtfromdataset : Window
        {
            public dtfromdataset()
            {
                InitializeComponent();
    
               
                this.DataContext = this;
    
                time.Interval = 5000;
                time.Elapsed += new ElapsedEventHandler(time_Elapsed);
                time.Start();
            }
            Timer time = new Timer();
    
           
    
            void time_Elapsed(object sender, ElapsedEventArgs e)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    StatusBarText = "Time is " + DateTime.Now.ToString("ddd-MM-yy HH:mm:ss tt");
                }));
            }
    
            private DataTable dt = new DataTable();
    
            public string StatusBarText
            {
                get { return (string)GetValue(StatusBarTextProperty); }
                set { SetValue(StatusBarTextProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for StatusBarText.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty StatusBarTextProperty =
                DependencyProperty.Register("StatusBarText", typeof(string), typeof(dtfromdataset), new UIPropertyMetadata(""));
    
    }
