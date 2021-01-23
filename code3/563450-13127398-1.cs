    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace MyGame
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // Create a new 'splash screen instance
                SplashScreen.SplashScreen ss = new SplashScreen.SplashScreen();
                // Show it
                ss.Visibility = System.Windows.Visibility.Visible;
                // Forces the splash screen visible
                Application.DoEvents();
                // Here's where you'd your actual loading stuff, but this
                // thread sleep is here to simulate 'loading'
                System.Threading.Thread.Sleep(5000);
                // Hide your splash screen
                ss.Visibility = System.Windows.Visibility.Hidden;
                // Start your main form, or whatever
                Application.Run(new Form1());
            }
        }
    }
