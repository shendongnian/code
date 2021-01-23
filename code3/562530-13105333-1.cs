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
                    txtCountDown.Text =  DateTime.Now.ToString("HH:mm:ss");
                    cDown = new DispatcherTimer();
                    cDown.Tick += new EventHandler(cDown_Tick);
                    cDown.Interval = new TimeSpan(0, 0, 1);
                    cDown.Start();
                }
       
                private void cDown_Tick(object sender, EventArgs e)
                {
                    DateTime? dt = null;
                    try
                    {
                        dt = DateTime.Parse(txtCountDown.Text);
                        if (dt != null)
                        {
                            txtCountDown.Text = dt.Value.AddSeconds(-1).ToString("HH:mm:ss");
                        }
                        else 
                        {
                            cDown.Stop();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
           
                }
            }
        }
