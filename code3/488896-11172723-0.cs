    void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        BitmapImage bmi = new BitmapImage();
        bmi.SetSource(e.Result);
        img.Source = bmi;
    }
