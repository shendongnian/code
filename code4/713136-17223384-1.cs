    namespace MyNamespace
    {
        public partial class frmSplashScreen : Form
        {
            private static frmSplashScreen splashScreen = null;
            private static Thread splashThread = null;
            private Double opacityInc = .03;
            private Double opacityDec = .1;
            private const Int32 iTimerInterval = 30;
    
            public frmSplashScreen()
            {
                InitializeComponent();
    
                Opacity = .0;
                timer1.Interval = iTimerInterval;
                timer1.Start();
            }
    
            private void frmSplashScreen_Load(Object sender, EventArgs e)
            {
                CenterToScreen();
            }
    
            public static void ShowSplashScreen()
            {
                if (splashScreen != null)
                    return;
                splashThread = new Thread(new ThreadStart(frmSplashScreen.ShowForm));
                splashThread.IsBackground = true;
                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.Start();
            }
    
            private static void ShowForm()
            {
                splashScreen = new frmSplashScreen();
                Application.Run(splashScreen);
            }
    
            public static void CloseForm()
            {
                if (splashScreen != null)
                    splashScreen.opacityInc = -splashScreen.opacityDec;
                splashThread = null;
                splashScreen = null;
            }
    
            private void timer1_Tick(Object sender, EventArgs e)
            {
                if (opacityInc > 0)
                {
                    if (Opacity < 1)
                        Opacity += opacityInc;
                }
                else
                {
                    if (Opacity > 0)
                        Opacity += opacityInc;
                    else
                        Close();
                }
            }
        }
    }
