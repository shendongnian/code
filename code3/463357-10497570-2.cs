    private int count1=0;
    private int count2=0;
    private int clickCounter = 0;
    private int timeLeft;
    private DispatcherTimer timer;
    private void StartTimer() {
        if (timer == null) {
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0,0,0,1);
			timer.Tick += timer_Tick;
        }
		timer.Stop();
		timeLeft = 20;
        timer.Start();
    }
    public void timer_Tick(object sender, object args) {
        if (timeLeft > 0) {
            timeLeft = timeLeft - 1;
            timerTextBlock.Text = Convert.ToString(timeLeft);
        } else {
            timer.Stop();
            if (clickCounter==2) {
                ShowResult();
                Button2.IsEnabled = false;
                StartButton.IsEnabled = false;
            } else {
                myMsg.Text = "Time's up!";
                Button1.IsEnabled = false;
                StartButton.IsEnabled = true;
            }
        }
    }
    private void Button1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
        count1++;
        textblock1.Text=count1.ToString();
    }
    private void Button2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
        count2++;
        textblock2.Text=count2.ToString();
    }
    private void StartButton_Click(object sender, RoutedEventArgs e) {
        clickCounter++;
		StartButton.IsEnabled = false;
        if (textblock1.Text == "0"){
            Button1.IsEnabled = true;
            StartTimer();
		} else {
            Button2.IsEnabled = true;
            StartTimer();
        }
    }
