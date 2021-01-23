    using System;
    using System.Windows;
    using System.Windows.Threading;
    namespace StartupSplash2
    {
    public partial class MainWindow : Window
    {
        private DispatcherTimer visibleTimer;
        private DispatcherTimer fadeoutTimer;
        private SplashScreen splash;
        private int visibleTime = (4000); //milliseconds of splash visible time
        private int fadeoutTime = (1500); //milliseconds of splash fadeout time
        public MainWindow()
        {   
            //hide this MainWindow window until splash completes
            this.Visibility = Visibility.Hidden; 
            InitializeComponent();
            splashIn(); //start the splash
        }
        private void splashIn()
        {
            splash = new SplashScreen("Resources/SplashScreen.png"); //ensure image property is set to Resource and not screen saver
            visibleTimer = new DispatcherTimer(); //timer controlling how long splash is visible
            visibleTimer.Interval = TimeSpan.FromMilliseconds(visibleTime);
            visibleTimer.Tick += showTimer_Tick; //when timer time is reached, call 'showTimer_Tick" to begin fadeout
            splash.Show(false, true); //display splash
            visibleTimer.Start();
        }
        private void showTimer_Tick(object sender, EventArgs e)
        {
            visibleTimer.Stop();
            visibleTimer = null; //clear the unused timer
            fadeoutTimer = new DispatcherTimer();
            fadeoutTimer.Interval = TimeSpan.FromMilliseconds(fadeoutTime); //a timer that runs while splash fades out and controlls when main window is displayed
            fadeoutTimer.Tick += fadeTimer_Tick; //when fadeout timer is reached, call 'fadeTimer_Tick' to show main window
            splash.Close(TimeSpan.FromMilliseconds(fadeoutTime)); //begin splash fadeout to close
            fadeoutTimer.Start();
        }
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            fadeoutTimer.Stop();
            fadeoutTimer = null; //clear the unused timer
            splash = null; //clear the splash var
            MainWindowReady(); //call method to display main window
        }
        public void MainWindowReady()
        {
            this.Visibility = Visibility.Visible;
            //Here is the start of the Main Window Code
            this.Content = "Ok, the app is ready to roll";
        }
      }
    }
