    private void holdResumeButton_Click(object sender, RoutedEventArgs e)
    {
            if ((string)holdResumeButton.Content == "Hold")
                holdResumeButton.Content = "Resume";
            else
                holdResumeButton.Content = "Hold";
    }
