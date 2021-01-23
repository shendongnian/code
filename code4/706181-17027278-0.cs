        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
                System.Threading.Thread.Sleep(DateTime.Now.TimeOfDay.Seconds + 3000);
        }
