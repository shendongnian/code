        namespace CountDown
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                private DispatcherTimer cDown;
                public MainWindow()
                {
                    InitializeComponent();
                    initialTime.Text = DateTime.Now.ToString("HH:mm:ss");
                    TimeSpan timeToDie = new TimeSpan(0, 0, 10); //Set the time "when the users load"
                    txtCountDown.Text = timeToDie.ToString();
                    cDown = new DispatcherTimer();
                    cDown.Tick += new EventHandler(cDown_Tick);
                    cDown.Interval = new TimeSpan(0, 0, 1);
                    cDown.Start();
                }
       
                private void cDown_Tick(object sender, EventArgs e)
                {
                    TimeSpan? dt = null;
                    try
                    {
                        dt = TimeSpan.Parse(txtCountDown.Text);
                        if (dt != null && dt.Value.TotalSeconds > 0  )
                        {
                            txtCountDown.Text = dt.Value.Add(new TimeSpan(0,0,-1)).ToString();
                        }
                        else 
                        {
                            cDown.Stop();
                        }
                    }
                    catch (Exception ex)
                    {
                         cDown.Stop();
                         Console.WriteLine(ex.Message);
                    }
           
                }
            }
        }
