    private void DisplayWarning(String message, int Interval = 3000)
        {
            Timer timer = new Timer();
            timer.Interval = Interval;
            lblWarning.Dispatcher.Invoke(new Action(() => lblWarning.Content = message));
            lblWarning.Dispatcher.Invoke(new Action(() => lblWarning.Visibility = Visibility.Visible));
            // above two line sets the visibility and shows the message and interval elapses hide the visibility of the label. Elapsed will we called after Start() method.
            timer.Elapsed += (s, en) => {
                lblWarning.Dispatcher.Invoke(new Action(() => lblWarning.Visibility = Visibility.Hidden));
                timer.Stop(); // Stop the timer(otherwise keeps on calling)
            };
            timer.Start(); // Starts the timer. 
        }
