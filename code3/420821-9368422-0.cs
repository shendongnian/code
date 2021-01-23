    OnVerifyClick(object sender, RoutedEventArgs e)
    {
        Button verifyButton = sender as Button;
        if(verifyButton == null) { return; }
    
        verifyButton.Content = "Verifying...";
        DoProcessing();
        verifyButton.Content = "Verified";    
    }
