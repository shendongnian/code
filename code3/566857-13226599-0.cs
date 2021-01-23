    class Tester
        {
        // Create splash screen instance and reference the image location.
        // IMPORTANT Ensure that the image properties are set to Resource and NOT Splash Screen
        private SplashScreen Splash = new SplashScreen("Resources/SplashScreen.png");
        public void Display()
        {
            Splash.Show(false, true);
            // pause the code, thus, displaying the splash for 3 seconds
            Thread.Sleep(3000); 
            // close the splash
            Close();
        }
        private void Close()
        {
            // sets the fadeout time in milliseconds
            int fadeOutTime = 1500; 
            // wait until the splash screen fadeOut has completed before writing to the console
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, ea) =>
            {
                // Run background task (fade out and close the splash)
                Splash.Close(TimeSpan.FromMilliseconds(fadeOutTime));
                // Sleep this worker but NOT the UI (for the same time as the fade out time)
                Thread.Sleep(fadeOutTime);
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                // Execute task after splash has closed completely
                Console.WriteLine("This is after the splash screen fadeOut completes.");
            };
            // start the background task, on it's own thread
            worker.RunWorkerAsync(); 
        }
    
    }
