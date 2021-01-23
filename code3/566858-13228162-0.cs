    using System;
    using System.Net;
    using System.Windows;
    namespace WpfApplication1
    {
      /// <summary>
      /// Interaction logic for Window1.xaml
      /// </summary>
      public partial class Window1 : Window
      {
        public Window1() {
          InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
          // show the splash screen
          // nb: Resources/SplashScreenImage.png file Properties ~ Build Action='Resource'
          var splashScreen = new SplashScreen("Resources/SplashScreenImage.png");
          splashScreen.Show(false); // don't close automatically
          // ... initialise my application ...
          Initialise();
          // close the splash screen.
          splashScreen.Close(TimeSpan.FromMilliseconds(250D));
        }
        private void Initialise() {
          // do my long-running application initialisation on the main thread. 
          // In reality you'd do this download asyncronously, but in this case
          // it serves as a simple proxy for some "heavy" inititalisation work.
          textBox1.Text = new WebClient().DownloadString("http://stackoverflow.com/questions/13213625/splashscreen-closetimespan-frommilliseconds-listen-for-closed-event");
        }
      }
    }
