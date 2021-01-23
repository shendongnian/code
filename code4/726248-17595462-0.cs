    private void button1_Click(object sender, RoutedEventArgs e)
    {
        Duration duration = new Duration(TimeSpan.FromSeconds(1));
        DoubleAnimation doubleanimation = new DoubleAnimation(progressBar1.Value + 10, duration);
        progressBar1.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
    }
