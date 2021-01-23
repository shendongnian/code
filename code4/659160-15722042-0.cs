        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            // Starts beep on background thread
            Thread beepThread = new Thread(new ThreadStart(PlayBeep));
            beepThread.IsBackground = true;
            beepThread.Start();
        }
        private void PlayBeep()
        {
            // Play 1000 Hz for max amount of time possible
            // So as long as you dont hold the mouse down for 2,147,483,647 milliseconds it should work.
            Console.Beep(1000, int.MaxValue);
        }
        private void Window_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            //Aborts the beep with a new 1ms beep on mouse up which finishes the task.
            Console.Beep(1000, 1);
        }
